import { Component, OnInit } from '@angular/core';
import Company from 'src/app/interfaces/company';
import { CompanyServiceService } from 'src/app/services/company-service.service';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.scss']
})

export class CompanyListComponent implements OnInit {
  companies: Company[] = [];

  constructor(private companyService: CompanyServiceService) { }
  
  ngOnInit(): void {
    this.companyService.getCompanies().subscribe(c => {
      //console.log(c)
      this.companies = c
    });
  }
}
