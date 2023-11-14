import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Company from 'src/app/interfaces/company';
import ProblemDetails from 'src/app/interfaces/problem-details';
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
  problemDetails: ProblemDetails | undefined;

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
          this.problemDetails = err.error;
        }
      });
  }

  loggedIn(): boolean {
    return this.localStorageService.getData("accessToken") != null;
  }
}
