import { Component, Input } from '@angular/core';
import Company from 'src/app/interfaces/company';

@Component({
  selector: 'app-company-list-item',
  templateUrl: './company-list-item.component.html',
  styleUrls: ['./company-list-item.component.scss']
})

export class CompanyListItemComponent {
  
  @Input() company: Company | undefined;

  getReviewNumberString(reviewNumber: number): string {
    switch(reviewNumber) {
      case 1:
        return "1 review";
      case 0:
        return "no reviews";
      default:
        return `${reviewNumber} reviews`
    }
  }
}
