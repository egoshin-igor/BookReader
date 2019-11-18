import { Component, OnInit, Input } from '@angular/core';

export interface IToolbarButton {
  name: string;
  onAction(): void;
}

@Component({
  selector: 'my-toolbar',
  templateUrl: './mat-toolbar.component.html',
  styleUrls: ['./mat-toolbar.component.scss']
})
export class MatToolbarComponent implements OnInit {

  @Input() buttons: IToolbarButton[];

  ngOnInit() {
    console.log(this.buttons[1].name);
  }
}
