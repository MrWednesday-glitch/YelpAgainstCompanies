import { Component, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import Star from 'src/app/interfaces/star';
import CompanyResponse from 'src/app/interfaces/company-response';
import { CompanyServiceService } from 'src/app/services/company-service.service';

@Component({
  selector: 'app-add-rating-form',
  templateUrl: './add-rating-form.component.html',
  styleUrls: ['./add-rating-form.component.scss']
})

export class AddRatingFormComponent {

  stars: Star[] = [
    {value: 1, viewValue: "1"},
    {value: 1.5, viewValue: "1.5"},
    {value: 2, viewValue: "2"},
    {value: 2.5, viewValue: "2.5"},
    {value: 3, viewValue: "3"},
    {value: 3.5, viewValue: "3.5"},
    {value: 4, viewValue: "4"},
    {value: 4.5, viewValue: "4.5"},
    {value: 5, viewValue: "5"},
  ];
  commentFormControl = new FormControl('');
  addCompanyResponse: CompanyResponse | undefined;
  @Input() companyId: number = 0;

  constructor(private companyService: CompanyServiceService) { }

  onSubmit(): void {
    //this.companyService.addRatingToCompany()
  }
}
