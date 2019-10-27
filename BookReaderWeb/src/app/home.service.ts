import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './services/base-service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class HomeService extends BaseService {

  private homeUrl = 'api/home';
  constructor(httpClient: HttpClient, cookieService: CookieService, router: Router) {
    super(httpClient, cookieService, router);
  }

  public async getName(): Promise<string> {
    const url = `${this.homeUrl}/my-name`;

    return (await this.Get<{name: string}>(url)).name;
  }
}
