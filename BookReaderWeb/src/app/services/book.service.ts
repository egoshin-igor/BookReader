import { Injectable, EventEmitter } from '@angular/core';
import { BaseService } from './base-service';
import { CookieService } from 'ngx-cookie-service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
  })
export class BookService extends BaseService {
    constructor(httpClient: HttpClient, cookieService: CookieService, router: Router) {
        super(httpClient, cookieService, router)
    }
}