import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import CompanyResponse from 'src/app/interfaces/company-response';
import { CompanyServiceService } from 'src/app/services/company-service.service';

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
  //message: string | undefined;
  //success: boolean = false;

  constructor(private companyService: CompanyServiceService) {}

  onSubmit(): void {
    let pictureUrl: string = "https://www.fryskekrite.nl/wordpress/wp-content/uploads/2017/03/No-image-available.jpg"
    if (this.pictureUrlFormControl.value != null) {
      pictureUrl = this.pictureUrlFormControl.value;
    }

    if (this.addressFormControl.valid 
      && this.cityFormControl.valid
      && this.nameFormControl.valid
      && this.postalCodeFormControl.valid) {
        console.log(this.nameFormControl.value!, this.addressFormControl.value!, this.postalCodeFormControl.value!, this.cityFormControl.value!, pictureUrl)
        this.companyService.saveCompany(this.nameFormControl.value!, this.addressFormControl.value!, this.postalCodeFormControl.value!, this.cityFormControl.value!, pictureUrl)
          .subscribe(x => {
            this.addCompanyResponse = x;
            //this.message = x.message;
            //this.success = x.success;
          }, y => this.addCompanyResponse = y.error);
    } else {
      console.error("You did not enter all the fields.")
    }
  }
}
