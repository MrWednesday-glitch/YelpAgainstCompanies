import { Component, OnInit } from '@angular/core';
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

  constructor(private companyService: CompanyServiceService, 
    private localStorageService: LocalStorageService) { }
  
  ngOnInit(): void {
    // this.companyService.getCompanies().subscribe(c => {
    //   this.companies = c
    // });

    //TODO Continue working from this point
    //TODO Make a pagination interface to catch c.headers.get('X-Pagination') and insert that into the paginator element
    //TODO If no page and pagesize given => default numbers (1, 10)
    this.companyService.getCompanies(1, 10).subscribe(c => {
      console.log(c.headers.get('X-Pagination'))

      this.companies = c.body;
      console.log(c);
    });
  }

  loggedIn(): boolean {
    return this.localStorageService.getData("accessToken") != null;
  }
}
