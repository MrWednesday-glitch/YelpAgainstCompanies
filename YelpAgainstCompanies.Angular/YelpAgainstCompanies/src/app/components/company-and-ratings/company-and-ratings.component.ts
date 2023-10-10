import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Company from 'src/app/interfaces/company';
import Rating from 'src/app/interfaces/rating';
import { CompanyServiceService } from 'src/app/services/company-service.service';
import { RatingService } from 'src/app/services/rating.service';

@Component({
  selector: 'app-company-and-ratings',
  templateUrl: './company-and-ratings.component.html',
  styleUrls: ['./company-and-ratings.component.scss']
})

export class CompanyAndRatingsComponent implements OnInit {
  company: Company | undefined;
  ratings: Rating[] = [];

  constructor(private route: ActivatedRoute, 
    private ratingService: RatingService,
    private companyService: CompanyServiceService) { }
    
  ngOnInit(): void {
    const companyId: number = Number(this.route.snapshot.paramMap.get("companyId"));
    this.companyService.getCompany(companyId).subscribe(c => { //todo make this prettier => make a singular "model " with both the company and all the ratings in a singular query
      this.company = c;
      this.ratingService.getRatingsPerCompany(companyId).subscribe(r => {
        this.ratings = r;
      });
    })         
  }
}
