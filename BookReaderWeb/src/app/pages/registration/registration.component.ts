import { Component, OnInit } from '@angular/core';
import { RegistrationRequestDto } from 'src/app/dto/account/registration-request.dto';
import { AccountService } from 'src/app/services/account.service';
import { MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  public registrationData: RegistrationRequestDto;

  constructor(private accountService: AccountService, private snackBar: MatSnackBar, private router: Router) {
    this.registrationData = {} as RegistrationRequestDto;
  }

  ngOnInit() {
  }

  public async register(): Promise<void> {
    console.log(this.registrationData);
    const isSuccess = await this.accountService.registrate(this.registrationData);
    if (isSuccess) {
      this.snackBar.open('Вы успешно зарегистрированы', null, {
        duration: 2000
      });
      this.router.navigate([`/home`])
    } else {
      this.snackBar.open('Упс! Что-то пошло не так. Попробуйте позже', null, {
        duration: 2000
      });
    }
  }

}
