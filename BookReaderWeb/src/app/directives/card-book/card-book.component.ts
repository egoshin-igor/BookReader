import { Component, OnInit, Input } from '@angular/core';
import { BookDto } from '../../dto/book-list/book.dto';

@Component({
  selector: 'card-book',
  templateUrl: './card-book.component.html',
  styleUrls: ['./card-book.component.scss']
})
export class CardBookComponent implements OnInit {

  @Input() book: BookDto;

  constructor() { }

  ngOnInit() {
  }

}
