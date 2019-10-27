import { Component, OnInit } from '@angular/core';
import { AuthRequestDto } from 'src/app/dto/account/auth-request.dto';
import { AccountService } from 'src/app/services/account.service';
import { MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'app-authorization',
  templateUrl: './authorization.component.html',
  styleUrls: ['./authorization.component.scss']
})
export class AuthorizationComponent implements OnInit {
  public authorizationData: AuthRequestDto;

  constructor(private accountService: AccountService, private snackBar: MatSnackBar, private router: Router) {
    this.authorizationData = {} as AuthRequestDto;
   }

  ngOnInit() {
  }

  public async authorize(): Promise<void>{
    console.log(this.authorizationData);
    const isSuccess = await this.accountService.auth(this.authorizationData);
    if (isSuccess) {
      this.snackBar.open('Вы успешно авторизованы', null, {
        duration: 2000
      });
      this.router.navigate([`/home`])
    } else {
      this.snackBar.open('Неправильный логин или пароль', null, {
        duration: 2000
      });
    }
  }

}
