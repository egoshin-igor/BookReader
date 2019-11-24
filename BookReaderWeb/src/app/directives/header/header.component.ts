import { Component, OnInit, Input } from '@angular/core';
import { AccountService } from 'src/app/services/account.service';
import { Router } from '@angular/router';

export interface IHeaderButton {
  name: string;
  onAction(): void;
}

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  private buttons: IHeaderButton[];
  constructor(private accountService: AccountService, private router: Router) {
    if(accountService.isAuthorized()) {
      this.buttons = this.getButtonsForAuthUser();
    } else {
      this.buttons = this.getButtonsForUnauthUser();
    }

    this.accountService.userAuthorized.subscribe(() => { this.buttons = this.getButtonsForAuthUser(); })
    this.accountService.userUnauthorized.subscribe(() => { this.buttons = this.getButtonsForUnauthUser(); })
  }

  ngOnInit() {
    console.log(this.buttons[1].name);
  }

  public redirectToHome() {
    this.router.navigate(["/home"]);
  }

  private getButtonsForAuthUser(): IHeaderButton[] {
    return [
      {
        name: "Выйти",
        onAction: () => {
          this.accountService.unauth();
          this.router.navigate(["/authorization"]);
        }
      },
      {
        name: "Добавить книгу",
        onAction: () => {
          this.router.navigate(["/add-book"]);
        }
      },
      {
        name: "Книги",
        onAction: () => {
          this.router.navigate(["/home"]);
        }
      }
    ]
  }

  private getButtonsForUnauthUser(): IHeaderButton[] {
    return [
      {
        name: "Авторизация",
        onAction: () => {
          this.router.navigate(["/authorization"]);
        }
      },
      {
        name: "Регистрация",
        onAction: () => {
          this.router.navigate(["/registration"]);
        }
      }
    ]
  }
}
