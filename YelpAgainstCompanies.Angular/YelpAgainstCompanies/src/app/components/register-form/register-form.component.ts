import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import ProblemDetails from 'src/app/interfaces/problem-details';
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
  //TODO Make a more pretty error response in html/css
  problemDetails: ProblemDetails | undefined;

  constructor(private authService: AuthService,
    private router: Router) {}

  ngOnInit(): void {
    this.succesfullyRegistered = false;
  }

  onSubmit(): void {
    if (this.emailFormControl.valid && this.passwordFormControl.valid) {
      this.authService.register(this.emailFormControl.value!, 
        this.passwordFormControl.value!, 
        this.firstnameFormControl.value!, 
        this.lastnameFormControl.value!)
        .subscribe({
          next: (r) => {
            this.succesfullyRegistered = r.succes;
            this.router.navigate(['/login']).then(() => window.location.reload())  
          },
          error: (err) => {
            this.problemDetails = err.error;
          }
        });
    } else {
      //TODO Find a way to get an error message here.
    }
  }
}
