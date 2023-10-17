import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.scss']
})

export class RegisterFormComponent implements OnInit {

  firstnameFormControl = new FormControl('', [Validators.required]);
  lastnameFormControl = new FormControl('', [Validators.required]);
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  passwordFormControl = new FormControl('', [Validators.required]);
  succesfullyRegistered: boolean | undefined;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.succesfullyRegistered = false;
  }

  onSubmit(): void {
    if (this.emailFormControl.valid && this.passwordFormControl.valid) {
      this.authService.register(this.emailFormControl.value!, 
        this.passwordFormControl.value!, 
        this.firstnameFormControl.value!, 
        this.lastnameFormControl.value!)
        .subscribe(registerResponse => this.succesfullyRegistered = registerResponse.succes);
    }
  }
}
