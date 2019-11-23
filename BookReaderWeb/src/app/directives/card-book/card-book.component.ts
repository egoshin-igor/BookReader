import { Component, OnInit, Input } from '@angular/core';

export interface BookData {
  name: string;
  imageUrl: string;
  author: string;
  genreName: string;
}

@Component({
  selector: 'card-book',
  templateUrl: './card-book.component.html',
  styleUrls: ['./card-book.component.scss']
})
export class CardBookComponent implements OnInit {

  @Input() book: BookData;

  constructor() { }

  ngOnInit() {
  }

}
