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
  pageSize: number = 10;
  pageIndex: number = 0;
  searchFormControl = new FormControl('', [Validators.minLength(3)]); //the minLength validator does not work?
  totalRecords: number = 0;
  cities: string[] = [];
  selectedCity: string | undefined;

  constructor(private companyService: CompanyServiceService, 
    private localStorageService: LocalStorageService) { }
  
  ngOnInit(): void {
    this.getCompanies('', this.pageIndex, this.pageSize);
  }

  loggedIn(): boolean {
    return this.localStorageService.getData("accessToken") != null;
  }

  getCompanies(searchTerm: string, currentPage: number, pageSize: number): void {
    this.companyService.getCompaniesWithPagination(currentPage + 1, pageSize, searchTerm)
      .subscribe(response => {
        this.companies = response.body as Company[];
        this.totalRecords = JSON.parse(response.headers.get('X-Pagination')!).TotalItemCount;
        
        this.cities = JSON.parse(response.headers.get('X-Pagination')!).Cities;
          //console.log(this.cities);
          // for (let city of this.cities) {
          //   //console.log (city);
          // }
      })
  }

  handlePageEvent(pageEvent: PageEvent): void {
    this.pageIndex = pageEvent.pageIndex;
    this.pageSize = pageEvent.pageSize;
    this.getCompanies(this.searchFormControl.value ?? '', this.pageIndex, this.pageSize);
  }

  search(): void {
    if (this.searchFormControl.value?.length! >= 3 || this.searchFormControl.value?.length! === 0) {
      this.pageIndex = 0;
      this.pageSize = 10;
      this.getCompanies(this.searchFormControl.value ?? '', this.pageIndex, this.pageSize);
    } else {
      console.log(`${this.searchFormControl.value} was less than three characters.`)
    }
  }

  resetSearchField(): void {
    this.getCompanies('', this.pageIndex, this.pageSize);
    this.searchFormControl.reset();
  }
}
