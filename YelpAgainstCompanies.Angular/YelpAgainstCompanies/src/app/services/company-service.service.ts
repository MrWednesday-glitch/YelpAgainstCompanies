import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { CustomHttpClientService } from './custom-http-client.service';
import Company from '../interfaces/company';
import CompanyResponse from '../interfaces/company-response';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class CompanyServiceService {

  constructor(private customHttpClient: CustomHttpClientService) { }

  getCompanies(): Observable<Company[]> {
    const url: string = "/company/companies";

    return this.customHttpClient.get<Company[]>(url);
  }

  getCompany(companyId: number): Observable<Company> {
    const url: string = "/company/" + companyId;

    return this.customHttpClient.get<Company>(url);
  }

  saveCompany(name: string, address: string, postalcode: string, city: string, pictureUrl: string): Observable<CompanyResponse> {
    const url: string = "/company/savecompanytodatabase";

    return this.customHttpClient.post<CompanyResponse>(url, {
      name, address, postalcode, city, pictureUrl
    }).pipe(catchError(this.handleError));
  }

  //TODO Why is this crossed out
  handleError(error: HttpErrorResponse) {
    return throwError(error);
  }
}
