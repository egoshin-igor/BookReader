import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class HomeService {

  private homeUrl = 'api/home';
  constructor(private http: HttpClient) { }

  public getName(): Observable<string> {
    const url = `${this.homeUrl}/my-name`;

    const httpOptions = {
      headers: new HttpHeaders({
        'responseType': 'text',
        
      })
    }
    return this.http.get(url, { responseType: 'text' });
  }
}
