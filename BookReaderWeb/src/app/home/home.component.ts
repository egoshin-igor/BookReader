import { Component, OnInit } from '@angular/core';
import { HomeService } from '../home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public user = "";

  constructor(private _homeService: HomeService) { }

  ngOnInit() {
    this._homeService.getName().subscribe( (respone) =>
    {
      console.log( respone );
      this.user = respone;
    } );
  }

}
