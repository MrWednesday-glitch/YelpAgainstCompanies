import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import CompanyResponse from 'src/app/interfaces/company-response';
import ProblemDetails from 'src/app/interfaces/problem-details';
import { CompanyServiceService } from 'src/app/services/company-service.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-add-company-form',
  templateUrl: './add-company-form.component.html',
  styleUrls: ['./add-company-form.component.scss']
})

export class AddCompanyFormComponent {

  nameFormControl = new FormControl('', [Validators.required]);
  addressFormControl = new FormControl('', [Validators.required]);
  postalCodeFormControl = new FormControl('', [Validators.required]);
  cityFormControl = new FormControl('', [Validators.required]);
  pictureUrlFormControl = new FormControl('');
  addCompanyResponse: CompanyResponse | undefined;
  problemDetails: ProblemDetails | undefined;

  constructor(private companyService: CompanyServiceService,
    private router: Router,
    private localStorageService: LocalStorageService) {}

  onSubmit(): void {
    let pictureUrl: string = "https://www.fryskekrite.nl/wordpress/wp-content/uploads/2017/03/No-image-available.jpg"
    if (this.pictureUrlFormControl.value != null) {
      pictureUrl = this.pictureUrlFormControl.value;
    }

    if (this.addressFormControl.valid 
      && this.cityFormControl.valid
      && this.nameFormControl.valid
      && this.postalCodeFormControl.valid) {
        this.companyService.saveCompany(this.nameFormControl.value!, this.addressFormControl.value!, this.postalCodeFormControl.value!, this.cityFormControl.value!, pictureUrl)
          .subscribe({
            next: (x) => {
              this.addCompanyResponse = x;
            }, 
            error: (err) => {
              this.problemDetails = err.error
              if (this.problemDetails?.status === 401){
                this.localStorageService.clearData();
                this.router.navigate(['/login']).then(() => window.location.reload());
              }
            }
          });
    } else {
      console.error("You did not enter all the fields.")
    }
  }
}
