import { Injectable } from '@angular/core';
import { CustomHttpClientService } from './custom-http-client.service';
import { Observable } from 'rxjs';
import Rating from '../interfaces/rating';

@Injectable({
  providedIn: 'root'
})

export class RatingService {

  constructor(private customHttpClient: CustomHttpClientService) { }

  getRatingsPerCompany(companyId: number): Observable<Rating[]> {
    const url: string = "/rating/" + companyId;

    return this.customHttpClient.get<Rating[]>(url);
  }
}
