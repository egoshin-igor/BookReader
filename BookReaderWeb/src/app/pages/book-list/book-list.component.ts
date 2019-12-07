import { Component, OnInit } from '@angular/core';
import { BookData } from '../../directives/card-book/card-book.component';
import { BookDto } from '../../dto/book-list/book.dto';
import { HomeService } from '../../services/home.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent implements OnInit {

  public allBooks: BookData[];
  public booksInReading:BookData[];
  public readedBooks: BookData[];

  constructor(private homeService: HomeService) {
    this.allBooks = [];
    this.booksInReading = [];
    this.readedBooks = [];
   }

  ngOnInit() {
    this.initTestData();

  }

  private initialize(): void {
    this.homeService.GetBooks().then((bookDtos:BookDto[]) => {
     // this.allBooks = bookDtos;
    });
  }

  private initTestData(): void {
    for(let i: number = 0; i < 10; i++) {
      this.allBooks.push({
        name: "Песнь льда и пламени",
        genreName: "Фантастика",
        imageUrl: "https://material.angular.io/assets/img/examples/shiba1.jpg",
        author: "Мартин"
      });

      this.booksInReading.push({
        name: "Песнь льда и пламени",
        genreName: "Фантастика",
        imageUrl: "https://www.stihi.ru/pics/2013/06/07/3257.jpg",
        author: "Мартин"
      });

      this.readedBooks.push({
        name: "Песнь льда и пламени",
        genreName: "Фантастика",
        imageUrl: "https://www.nastol.com.ua/pic/201502/2560x1440/nastol.com.ua-128496.jpg",
        author: "Мартин"
      });
    }
  }


}
