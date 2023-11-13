import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import LoginResponse from '../interfaces/login-response';
import RegisterResponse from '../interfaces/register-response';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private baseUrl: string = environment.apiUrl.valueOf();

  constructor(private httpClient: HttpClient) { }

  login(userName: string, password: string, firstname: string, lastname: string): Observable<LoginResponse> {
    return this.httpClient.post<LoginResponse>(this.baseUrl + "/authority/token", {
      email: userName, 
      firstname,
      lastname,
      password
    })
      .pipe(catchError(this.handleError));
  }

  register(username: string, password: string, firstname: string, lastname: string): Observable<RegisterResponse> {
    return this.httpClient.post<RegisterResponse>(this.baseUrl + "/authority/register", {
     email: username,
     firstname,
     lastname,
     password 
    })
      .pipe(catchError(this.handleError));
  }

  handleError(error: HttpErrorResponse) {
    return throwError(() => error);
  }
}
