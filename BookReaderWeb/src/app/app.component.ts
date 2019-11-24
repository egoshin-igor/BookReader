import { Component } from '@angular/core';
import {IHeaderButton} from './directives/header/header.component'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'BookReaderWeb';
  public mybuttons: IHeaderButton[];

  constructor() {
    this.mybuttons = [{name: "Регистрация", onAction: () => {}}, {name: "Авторизация", onAction: () => {}}];
  }
}