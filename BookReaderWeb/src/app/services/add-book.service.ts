import { Injectable, EventEmitter } from '@angular/core';
import { BaseService } from './base-service';
import { CookieService } from 'ngx-cookie-service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { GenreDto } from '../dto/app/genre.dto';
import { AddBookDto } from '../dto/add-book/add-book.dto';

@Injectable({
    providedIn: 'root'
})
export class AddBookService extends BaseService {
    private readonly baseUrl = 'api/add-book';

    constructor(httpClient: HttpClient, cookieService: CookieService, router: Router) {
        super(httpClient, cookieService, router);
    }

    public async addBook( addBookDto: AddBookDto ): Promise<void> {
        const url = `${this.baseUrl}`

        const formData = new FormData();
        formData.append(addBookDto.bookFile.name, addBookDto.bookFile);
        formData.append(addBookDto.bookImage.name, addBookDto.bookImage);

        const data: string = JSON.stringify(
            { 
                name: addBookDto.name,
                author: addBookDto.author,
                genreId: addBookDto.genreId
            }
        );
        formData.append('data', data );

        await this.Post(url, formData );
    }

    public async getGenres(): Promise<GenreDto[]> {
        const url = `${this.baseUrl}/genres`;

        const response: GenreDto[] = await this.Get(url);
        return response;
    }
}
