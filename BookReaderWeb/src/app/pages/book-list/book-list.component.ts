import { Component, OnInit } from '@angular/core';
import { BookDto } from '../../dto/book-list/book.dto';
import { HomeService } from '../../services/home.service';
import { UserBookStatus } from '../../constants/userBookStatus';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent implements OnInit {

  public allBooks: BookDto[];
  public booksInReading:BookDto[];
  public readedBooks: BookDto[];

  constructor(private homeService: HomeService) {
    this.allBooks = [];
    this.booksInReading = [];
    this.readedBooks = [];
   }

  ngOnInit() {
    this.initTestData();
    this.initialize();
  }

  private initialize(): void {
    this.homeService.GetBooks().then((bookDtos:BookDto[]) => {
      if (!bookDtos) {
        return;
      }

      this.allBooks = bookDtos;
      this.booksInReading = bookDtos.filter((bd: BookDto) => bd.status === UserBookStatus.Reading);
      this.readedBooks = bookDtos.filter((bd: BookDto) => bd.status === UserBookStatus.Readed);
    });
  }

  private initTestData(): void {
    for(let i: number = 0; i < 10; i++) {
      this.allBooks.push({
        name: "Песнь льда и пламени",
        jenreName: "Фантастика",
        imagePath: "https://material.angular.io/assets/img/examples/shiba1.jpg",
        author: "Мартин",
        status: UserBookStatus.ReadyToRead
      });

      this.booksInReading.push({
        name: "Песнь льда и пламени",
        jenreName: "Фантастика",
        imagePath: "https://www.stihi.ru/pics/2013/06/07/3257.jpg",
        author: "Мартин",
        status: UserBookStatus.ReadyToRead
      });

      this.readedBooks.push({
        name: "Песнь льда и пламени",
        jenreName: "Фантастика",
        imagePath: "https://www.nastol.com.ua/pic/201502/2560x1440/nastol.com.ua-128496.jpg",
        author: "Мартин",
        status: UserBookStatus.ReadyToRead
      });
    }
  }


}
