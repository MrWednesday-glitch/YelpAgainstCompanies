import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class CustomHttpClientService {
  private baseUrl: string = environment.apiUrl.valueOf();

  constructor(private httpClient: HttpClient) { }

  get<T>(url: string): Observable<T> {
    return this.httpClient.get<T>(this.baseUrl + url, {
      headers: this.getHeaders()
    });
  }

  getHeaders(): any {
    var token = localStorage.getItem("accessToken");

    if (token) {
      return { Authorization: `Bearer ${token}`};
    } else {
      return null;
    }
  }
}
