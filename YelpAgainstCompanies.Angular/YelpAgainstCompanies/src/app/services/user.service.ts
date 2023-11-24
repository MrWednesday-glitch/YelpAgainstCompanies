import { Injectable } from '@angular/core';
import { CustomHttpClientService } from './custom-http-client.service';
import User from '../interfaces/user';
import { Observable, catchError, throwError } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private customHttpClient: CustomHttpClientService) { }

  getUser(): Observable<User> {
    const url: string = "/user-management";

    return this.customHttpClient.get<User>(url)
      .pipe(catchError(this.handleError));
  }

  handleError(error: HttpErrorResponse) {
    return throwError(() => error);
  }
}
