import { Injectable, EventEmitter } from '@angular/core';
import { BaseService } from './base-service';
import { CookieService } from 'ngx-cookie-service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BookDto } from '../dto/book-list/book.dto';

@Injectable({
    providedIn: 'root'
  })
export class BookService extends BaseService {
    private readonly homeUrl = 'api/home';
    
    constructor(httpClient: HttpClient, cookieService: CookieService, router: Router) {
        super(httpClient, cookieService, router)
    }

    public async GetBooks(): Promise<BookDto[]> {
        const url = `${this.homeUrl}/books`;
        const response: BookDto[] = await this.Get(url);
        return response;
    }

    public async DeleteBook(bookId: number) {
        const url = `${this.homeUrl}/delete/${bookId}`;
        await this.Post(url, {});
    }
}