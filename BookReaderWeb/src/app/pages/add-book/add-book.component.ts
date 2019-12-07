import { Component, OnInit } from '@angular/core';
import { ImageCroppedEvent } from 'ngx-image-cropper';
import { AddBookDto } from 'src/app/dto/add-book/add-book.dto';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AddBookService } from 'src/app/services/add-book.service';
import { GenreDto } from 'src/app/dto/app/genre.dto';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.scss']
})
export class AddBookComponent implements OnInit {
  addBookDto: AddBookDto;
  bookImageChangedEvent: any = '';
  addBookFormGroup: FormGroup;
  image: string = '';
  fileImage: File;
  genres: GenreDto[] = [];
  isFileDownloaded = false;

  constructor(
    private formBuilder: FormBuilder,
    private addBookService: AddBookService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.addBookDto = {
      name: '',
      author: '',
      bookFile: null,
      bookImage: null
    } as AddBookDto;

    this.addBookFormGroup = this.formBuilder.group({
      name: ['', Validators.required],
      author: ['', Validators.required],
      bookImage: ['', Validators.required],
      bookFile: ['', Validators.required],
      genreId: ['', Validators.required],
      bookFileValidator: ['', Validators.required]
    });
    this.addBookFormGroup.controls['bookFileValidator'].enable();
    this.addBookService.getGenres().then((genres) => this.genres = genres);
  }

  onChangeBookImageInput($event: any): void {
    const files: FileList = $event.srcElement.files;

    if (files.length > 0) {
      const file = files.item(0);
      this.fileImage = file;
      this.bookImageChangedEvent = $event;
    }
  }
  
  onChangeBookFileInput($event: any): void {
    const files: FileList = $event.srcElement.files;

    if (files.length > 0) {
      const file = files.item(0);
      this.addBookDto.bookFile = file;
      this.addBookFormGroup.controls['bookFileValidator'].disable();
      this.isFileDownloaded = true;
    }
  }

  saveBookImage($event: ImageCroppedEvent): void {
    this.image = $event.base64;
    const name = this.fileImage.name;
    const lastModified = this.fileImage.lastModified;
    this.addBookDto.bookImage = this.blobToFile(this.dataURItoBlob($event.base64), name, lastModified);
  }

  dataURItoBlob(dataUri: string) {
    const binary = atob(dataUri.split(',')[1]);
    const array = [];
    for (let i = 0; i < binary.length; i++) {
      array.push(binary.charCodeAt(i));
    }
    return new Blob([new Uint8Array(array)], {
      type: 'image/png'
    });
  }

  isImageDownloaded(): boolean {
    return this.image !== '';
  }

  onSaveClick(): void {
    this.addBookService.addBook( this.addBookDto ).then(() => {
      this.snackBar.open('Вы успешно добавили книгу', null, {
        duration: 2000
      });
    }).catch(() => {
      this.snackBar.open('Не удалось добавить книгу. Попробуйте позже', null, {
        duration: 2000
      });
    });
    
    this.reset();
  }

  onResetClick(): void {
    this.reset();
  }

  private blobToFile(blob: Blob, fileName: string, lastModified: number): File {
    var file = new File([blob], fileName, { lastModified: lastModified });
    return file
  }

  private reset(): void {
    this.addBookDto = {
      name: '',
      author: '',
      bookFile: null,
      bookImage: null
    } as AddBookDto;
    this.image = '';
    this.addBookFormGroup.controls['bookFileValidator'].enable();
    this.addBookFormGroup.controls['bookImage'].setValue('');
    this.addBookFormGroup.controls['bookFile'].setValue('');
    this.addBookFormGroup.controls['bookImage'].setErrors({ 'incorrect': true });
    this.isFileDownloaded = false;
  }
}
