import { Component } from '@angular/core';
import {IToolbarButton} from '../app/directives/mat-toolbar/mat-toolbar.component'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'BookReaderWeb';
  public mybuttons: IToolbarButton[];

  constructor() {
    this.mybuttons = [{name: "Регистрация", onAction: () => {}}, {name: "Авторизация", onAction: () => {}}];
  }
}