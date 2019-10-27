import { Component, OnInit } from '@angular/core';

export class AuthorizationData {
  public login;
  public password;
}

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.scss']
})
export class AuthorizationComponent implements OnInit {
  public 

  constructor() { }

  ngOnInit() {
  }

}
