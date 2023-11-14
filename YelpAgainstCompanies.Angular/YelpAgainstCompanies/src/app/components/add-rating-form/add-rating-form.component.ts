import { Component, Input } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import Star from 'src/app/interfaces/star';
import CompanyResponse from 'src/app/interfaces/company-response';
import { CompanyServiceService } from 'src/app/services/company-service.service';
import { Router } from '@angular/router';
import ProblemDetails from 'src/app/interfaces/problem-details';

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
  @Input() companyId!: number;
  addCompanyResponse: CompanyResponse | undefined;
  scoreFormControl = new FormControl('', Validators.required)
  commentFormControl = new FormControl('');
  problemDetails: ProblemDetails | undefined;

  constructor(private companyService: CompanyServiceService,
    private router: Router) { }

  onSubmit(): void {
    if (this.scoreFormControl.valid) {
      var score: number = +this.scoreFormControl.value!;
      var comment: string | null;
      if (this.commentFormControl.value === '') {
        comment = null;
      } else {
        comment = this.commentFormControl.value;
      }

      this.companyService.addRatingToCompany(this.companyId, score, comment)
        .subscribe({
          next: (x) => {
            this.addCompanyResponse = x;
            this.router.navigate(['/rating/' + this.companyId]).then(() => window.location.reload());
          },
          error: (err) => {
            this.problemDetails = err.error;
          }
        });
      } else {
      console.error("You did not select a score.");
    }
  }
}
