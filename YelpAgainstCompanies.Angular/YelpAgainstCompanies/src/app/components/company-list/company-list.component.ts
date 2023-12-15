import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import Company from 'src/app/interfaces/company';
import { CompanyServiceService } from 'src/app/services/company-service.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.scss']
})

export class CompanyListComponent implements OnInit {
  
  companies: Company[] = [];
  length: number = 10;
  pageIndex: number = 1;


  constructor(private companyService: CompanyServiceService, 
    private localStorageService: LocalStorageService) { }
  
  ngOnInit(): void {
    this.companyService.getCompanies(this.pageIndex, this.length).subscribe(c => {
      this.companies = c.body;
      this.length = JSON.parse(c.headers.get('X-Pagination')).TotalItemCount;
    });
  }

  loggedIn(): boolean {
    return this.localStorageService.getData("accessToken") != null;
  }

  handlePageEvent(pageEvent: PageEvent) {
    this.companyService.getCompanies(pageEvent.pageIndex + 1, pageEvent.pageSize).subscribe(c => {
      this.companies = c.body;
    });
  }
}
