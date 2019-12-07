import { Component, OnInit, Input } from '@angular/core';
import { BookDto } from '../../dto/book-list/book.dto';
import { BookService } from '../../services/book.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'card-book',
  templateUrl: './card-book.component.html',
  styleUrls: ['./card-book.component.scss']
})
export class CardBookComponent implements OnInit {

  @Input() book: BookDto;
  @Input() onBookDeleted: Function;

  constructor(private bookService: BookService, private snackBar: MatSnackBar) { 

  }

  ngOnInit() {
  }

  public openBook(): void {
    
  }

  public deleteBook(): void {
      this.bookService.DeleteBook( this.book.id ).then(() => {
        this.onBookDeleted();
        this.snackBar.open('Книга удалена', null, {
          duration: 2000
        });
      }).catch(() => {
        this.snackBar.open('Ой я что-то упал, простите :(', null, {
          duration: 2000
        });
      });
  }

}
