import { Injectable } from '@angular/core';
import { CustomHttpClientService } from './custom-http-client.service';
import { Observable, catchError, throwError } from 'rxjs';
import Rating from '../interfaces/rating';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class RatingService {

  constructor(private customHttpClient: CustomHttpClientService) { }

  getRatingsPerCompany(companyId: number): Observable<Rating[]> {
    const url: string = "/rating/" + companyId;

    return this.customHttpClient.get<Rating[]>(url)
      .pipe(catchError(this.handleError));
  }

  handleError(error: HttpErrorResponse) {
    return throwError(() => error);
  }
}
