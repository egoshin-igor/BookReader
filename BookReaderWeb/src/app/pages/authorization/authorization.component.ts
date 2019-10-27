import { Component, OnInit } from '@angular/core';

export class AuthorizationData {
  public login: string;
  public password: string;
}

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.scss']
})
export class AuthorizationComponent implements OnInit {
  public authorizationData: AuthorizationData = new AuthorizationData();

  constructor() { }

  ngOnInit() {
  }

  public authorize(data: AuthorizationData): void{
      console.log(data);
  }

}
