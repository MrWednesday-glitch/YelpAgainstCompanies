import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import Company from 'src/app/interfaces/company';
import Rating from 'src/app/interfaces/rating';
import { CompanyServiceService } from 'src/app/services/company-service.service';

@Component({
  selector: 'app-company-and-ratings',
  templateUrl: './company-and-ratings.component.html',
  styleUrls: ['./company-and-ratings.component.scss']
})

export class CompanyAndRatingsComponent implements OnInit {
  company: Company | undefined;
  ratings: Rating[] | undefined = [];

  constructor(private route: ActivatedRoute, 
    private companyService: CompanyServiceService) { }
    
  ngOnInit(): void {
    const companyId: number = Number(this.route.snapshot.paramMap.get("companyId"));
    this.companyService.getCompany(companyId).subscribe(c => {
      this.company = c;
      this.ratings = c.ratingDTOs;
    })         
  }
}
