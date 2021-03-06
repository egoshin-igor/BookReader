import { HttpClient, HttpHeaders, HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { HttpStatusCode } from '../constants/http-status-code';
import { CookieService } from 'ngx-cookie-service';
import { UserTokenDto } from '../dto/account/user-token.dto';
import { Router } from '@angular/router';

export interface Response<R> {
    result: R;
    statusCode: number;
}

export class BaseService {
    protected accessTokenField = 'accessToken';
    protected refreshTokenField = 'refreshToken';
    private accountBaseUrl = 'api/account'

    constructor(private http: HttpClient, protected cookieService: CookieService, private router: Router) {
    }

    protected async Get<HttpR>(url: string): Promise<HttpR> {
        let response: Response<HttpR> = await  this.TryGet( url );

        if (response.statusCode == HttpStatusCode.Ok) {
            return response.result;
        }
        if (response.statusCode != HttpStatusCode.Unauthorized) {
            return null;
        }

        const isTokensUpdated: boolean = await this.updateTokens();
        if (!isTokensUpdated) {
            this.router.navigate([`/authorization`]);
            throw 'You are unauthorized';
        }

        response = await this.TryGet(url);
        if (response.statusCode === HttpStatusCode.Ok ) {
            return response.result;
        } else {
            this.router.navigate([`/authorization`]);
            throw 'You are unauthorized';
        }
    }
    
    protected async Post<HttpRequest, HttpResponse>(url: string, request: HttpRequest): Promise<HttpResponse> {
        let response: Response<HttpResponse> = await this.TryPost(url, request);
        console.log(response);
        
        if (response.statusCode == HttpStatusCode.Ok) {
            return response.result;
        }
        if (response.statusCode != HttpStatusCode.Unauthorized) {
            return null;
        }

        const isTokensUpdated: boolean = await this.updateTokens();
        if (!isTokensUpdated) {
            this.router.navigate([`/authorization`]);
            throw 'You are unauthorized';
        }

        response = await this.TryPost(url, request);
        if (response.statusCode === HttpStatusCode.Ok) {
            return response.result;
        } else {
            this.router.navigate([`/authorization`]);
            throw 'You are unauthorized';
        }
    }

    private async TryGet<HttpR>(url: string): Promise<Response<HttpR>> {
        const httpOptions = this.generateHttpOptions();

        const result = {
            result: null,
        } as Response<HttpR>;
        try {
            const response: HttpR = await this.http.get<HttpR>(url, httpOptions).toPromise();
            result.statusCode = HttpStatusCode.Ok;
            result.result = response;
        } catch (error) {
            result.statusCode = error.status;
        }

        return result;
    }

    private async TryPost<HttpRequest, HttpResponse>(url: string, request: HttpRequest ): Promise<Response<HttpResponse>> {
        const httpOptions = this.generateHttpOptions();

        const result = {
            result: null,
        } as Response<HttpResponse>;
        try {
            const response: HttpResponse = await this.http.post<HttpResponse>(url, request, httpOptions).toPromise();
            result.statusCode = HttpStatusCode.Ok;
            result.result = response;
        } catch (error) {
            result.statusCode = error.status;
        }

        return result;
    }

    private async updateTokens(): Promise<boolean> {
        const accountUrl = `${this.accountBaseUrl}/update-tokens`
        const refreshToken = this.cookieService.get(this.refreshTokenField);
        const newTokensResponse: Response<UserTokenDto> = await this.TryPost(accountUrl, { refreshToken: refreshToken });
        if (!newTokensResponse.result) {
            return false;
        }
        const newTokens = newTokensResponse.result;
        this.cookieService.set(this.accessTokenField, newTokens.accessToken);
        this.cookieService.set(this.refreshTokenField, newTokens.refreshToken);

        return true;
    }

    private generateHttpOptions(): { headers: HttpHeaders } {
        let accessToken = this.cookieService.get(this.accessTokenField);
        if (!accessToken) {
            accessToken = '';
        }
        const httpOptions = {
            headers: new HttpHeaders({
                'Authorization': 'Bearer ' + accessToken
            }),
        }

        return httpOptions;
    }
}