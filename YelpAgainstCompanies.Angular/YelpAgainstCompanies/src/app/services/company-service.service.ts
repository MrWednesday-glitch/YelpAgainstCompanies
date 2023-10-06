import { Injectable } from '@angular/core';
import { Observable, catchError, of } from 'rxjs';
import { CustomHttpClientService } from './custom-http-client.service';
import Company from '../interfaces/company';

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
}
