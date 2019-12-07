import { Component, OnInit } from '@angular/core';
import { ImageCroppedEvent } from 'ngx-image-cropper';
import { AddBookDto } from 'src/app/dto/add-book/add-book.dto';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AddBookService } from 'src/app/services/add-book.service';
import { GenreDto } from 'src/app/dto/app/genre.dto';

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
  genres: GenreDto[] = [];
  isFileDownloaded = false;

  constructor(
    private formBuilder: FormBuilder,
    private addBookService: AddBookService
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
      bookFileValidator: ['', Validators.required]
    });
    this.addBookFormGroup.controls['bookFileValidator'].enable();
    this.addBookService.getGenres().then((genres) => this.genres = genres);
  }

  onChangeBookImageInput($event: any): void {
    const files: FileList = $event.srcElement.files;

    if (files.length > 0) {
      this.bookImageChangedEvent = $event;
    }
  }
  
  onChangeBookFileInput($event: any): void {
    const files: FileList = $event.srcElement.files;

    if (files.length > 0) {
      const file = files.item(0);
      this.addBookFormGroup.controls['bookFileValidator'].disable();
      this.isFileDownloaded = true;
    }
  }

  saveBookImage($event: ImageCroppedEvent): void {
    this.image = $event.base64;
  }

  isImageDownloaded(): boolean {
    return this.image !== '';
  }

  async onSaveClick(): Promise<void> {
    // const addedBookId = await this.addBook();
    // this._router.navigate([`/book/${addedBookId}`])
  }

  async onSaveAndAddMoreClick(): Promise<void> {
    // await this.addBook();
    this.reset();
  }

  onResetClick(): void {
    this.reset();
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
    this.addBookFormGroup.controls['bookImage'].setErrors({ 'incorrect': true });
    this.isFileDownloaded = false;
  }
}
