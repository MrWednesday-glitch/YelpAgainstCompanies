import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Company from 'src/app/interfaces/company';
import Rating from 'src/app/interfaces/rating';
import { CompanyServiceService } from 'src/app/services/company-service.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-company-and-ratings',
  templateUrl: './company-and-ratings.component.html',
  styleUrls: ['./company-and-ratings.component.scss']
})

export class CompanyAndRatingsComponent implements OnInit {

  company: Company | undefined;
  ratings: Rating[] | undefined = [];
  companyId: number = 0;
  //TODO Make a more pretty error response in html/css
  httpError: HttpErrorResponse | undefined;

  constructor(private route: ActivatedRoute, 
    private companyService: CompanyServiceService,
    private localStorageService: LocalStorageService) { }
    
  ngOnInit(): void {
    const companyId: number = Number(this.route.snapshot.paramMap.get("companyId"));
    this.companyId = companyId;
    this.companyService.getCompany(companyId)
      .subscribe({
        next: (c) => {
          this.company = c;
          this.ratings = c.ratings;
        },
        error: (err) => {
          this.httpError = err;
        }
      });
  }

  loggedIn(): boolean {
    return this.localStorageService.getData("accessToken") != null;
  }
}
