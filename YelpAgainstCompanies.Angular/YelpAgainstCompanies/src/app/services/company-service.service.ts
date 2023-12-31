import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { CustomHttpClientService } from './custom-http-client.service';
import Company from '../interfaces/company';
import CompanyResponse from '../interfaces/company-response';
import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class CompanyServiceService {

  private baseUrl: string = environment.apiUrl.valueOf();

  constructor(private customHttpClient: CustomHttpClientService,
    private httpClient: HttpClient) { }

  getCompaniesWithPagination(pageNumber: number, pageSize: number, searchTerm: string, cityName: string): Observable<HttpResponse<any>> {
    let url: string = `${this.baseUrl}/companies?pageSize=${pageSize}&pageNumber=${pageNumber}`;

    if (searchTerm) {
      if (url.indexOf('&') > -1) {
        url = url + `&searchTerm=${searchTerm}`;
      } else {
        url = url + `searchTerm=${searchTerm}`;
      }
    }

    if (cityName) {
      if (url.indexOf('&') > -1) {
        url = url + `&cityName=${cityName}`;
      } else {
        url = url + `cityName=${cityName}`;
      }
    }

    return this.httpClient.get<HttpResponse<any>>(url, {observe: 'response'});
  }

  getCompanies(): Observable<Company[]> {
    const url: string = "/companies";

    return this.customHttpClient.get<Company[]>(url);
  }

  getCompany(companyId: number): Observable<Company> {
    const url: string = "/companies/" + companyId;

    return this.customHttpClient.get<Company>(url)
      .pipe(catchError(this.handleError));
  }

  saveCompany(name: string, address: string, postalcode: string, city: string, pictureUrl: string): Observable<CompanyResponse> {
    const url: string = "/companies";

    return this.customHttpClient.post<CompanyResponse>(url, {
      name, 
      address, 
      postalcode, 
      city, 
      pictureUrl
    })
      .pipe(catchError(this.handleError));
  }

  addRatingToCompany(companyId: number, score: number, comment: string | null): Observable<CompanyResponse> {
    const url: string = "/companies/" + companyId + "/rating";

    return this.customHttpClient.post<CompanyResponse>(url, {
      score,
      comment
    })
      .pipe(catchError(this.handleError));
  }

  handleError(error: HttpErrorResponse) {
    return throwError(() => error);
  }
}
