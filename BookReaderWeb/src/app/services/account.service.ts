import { Injectable } from '@angular/core';
import { BaseService } from './base-service';
import { CookieService } from 'ngx-cookie-service';
import { HttpClient } from '@angular/common/http';
import { RegistrationRequestDto } from '../dto/account/registration-request.dto';
import { UserTokenDto } from '../dto/account/user-token.dto';
import { AuthRequestDto } from '../dto/account/auth-request.dto';

@Injectable({
  providedIn: 'root'
})
export class AccountService extends BaseService {
  private accountUrl = 'api/account';

  constructor(httpClient: HttpClient, cookieService: CookieService ) {
    super(httpClient, cookieService);
  }

  public async registrate(registrationRequest: RegistrationRequestDto): Promise<boolean> {
    const url = `${this.accountUrl}/registrate`

    const response: UserTokenDto = await this.Post(url, registrationRequest);
    if (!response) {
      return false;
    }

    this.cookieService.set(this.accessTokenField, response.accessToken);
    this.cookieService.set(this.refreshTokenField, response.refreshToken);
    
    return true;
  }

  public async auth(authRequest: AuthRequestDto ): Promise<boolean> {
    const url = `${this.accountUrl}/auth`

    const response: UserTokenDto = await this.Post(url, authRequest);
    if (!response) {
      return false;
    }

    this.cookieService.set(this.accessTokenField, response.accessToken);
    this.cookieService.set(this.refreshTokenField, response.refreshToken);

    return true;
  }
}
