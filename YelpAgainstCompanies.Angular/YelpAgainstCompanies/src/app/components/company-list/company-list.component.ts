import { animate, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import Company from 'src/app/interfaces/company';
import { CompanyServiceService } from 'src/app/services/company-service.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';

const enterTransition = transition(':enter', [
  style({
    opacity: 0
  }),
  animate('1s ease-in', style({opacity: 1})),
]);
const fadeIn = trigger('fadeIn', [enterTransition]);

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.scss'],
  animations: [fadeIn],
})

export class CompanyListComponent implements OnInit {
  
  companies: Company[] = [];
  length: number = 10;
  pageIndex: number = 1;
  searchFormControl = new FormControl('', [Validators.minLength(3)]);


  constructor(private companyService: CompanyServiceService, 
    private localStorageService: LocalStorageService) { }
  
  ngOnInit(): void {
    this.companyService.getCompaniesWithPagination(this.pageIndex, this.length).subscribe(c => {
      this.companies = c.body;
      this.length = JSON.parse(c.headers.get('X-Pagination')).TotalItemCount;
    });
  }

  loggedIn(): boolean {
    return this.localStorageService.getData("accessToken") != null;
  }

  handlePageEvent(pageEvent: PageEvent) {
    this.companyService.getCompaniesWithPagination(pageEvent.pageIndex + 1, pageEvent.pageSize).subscribe(c => {
      this.companies = c.body;
    });
  }

  search(): void {
    if (this.searchFormControl.valid && this.searchFormControl.value != "") {
      console.log(this.searchFormControl.value);
    }
  }
}
