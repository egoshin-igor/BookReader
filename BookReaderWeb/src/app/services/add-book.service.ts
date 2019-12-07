import { Injectable, EventEmitter } from '@angular/core';
import { BaseService } from './base-service';
import { CookieService } from 'ngx-cookie-service';
import { HttpClient } from '@angular/common/http';
import { RegistrationRequestDto } from '../dto/account/registration-request.dto';
import { UserTokenDto } from '../dto/account/user-token.dto';
import { AuthRequestDto } from '../dto/account/auth-request.dto';
import { Router } from '@angular/router';
import { GenreDto } from '../dto/app/genre.dto';

@Injectable({
    providedIn: 'root'
})
export class AddBookService extends BaseService {
    private readonly baseUrl = 'api/add-book';

    constructor(httpClient: HttpClient, cookieService: CookieService, router: Router) {
        super(httpClient, cookieService, router);
    }

    public async getGenres(): Promise<GenreDto[]> {
        const url = `${this.baseUrl}/genres`;

        const response: GenreDto[] = await this.Get(url);
        return response;
    }
}
