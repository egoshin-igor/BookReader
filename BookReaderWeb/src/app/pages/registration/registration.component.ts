import { Component, OnInit } from '@angular/core';

export class RegstrationData{
  public login: string;
  public password: string;
  public firstName: string;
  public lastName: string;
}

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  public registrationData: RegstrationData;

  constructor() {
    this.registrationData = new RegstrationData();
  }

  ngOnInit() {
  }

  public register(data: RegstrationData): void {
    console.log(data);
  }

}
