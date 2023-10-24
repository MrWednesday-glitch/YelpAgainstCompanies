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
    this.companyService.getCompanies().subscribe(c => {
      //console.log(c)
      this.companies = c
    });
  }

  loggedIn(): boolean {
    return this.localStorageService.getData("accessToken") != null;
  }
}
