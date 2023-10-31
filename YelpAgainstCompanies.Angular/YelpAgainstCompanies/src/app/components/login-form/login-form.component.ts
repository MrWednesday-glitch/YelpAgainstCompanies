import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})

export class LoginFormComponent {

  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  passwordFormControl = new FormControl('', [Validators.required]);

  constructor(private authService: AuthService, 
    private localStorageService: LocalStorageService,
    private router: Router) {}

  onSubmit(): void {
    if (this.emailFormControl.valid && this.passwordFormControl.valid) {
      this.authService.login(this.emailFormControl.value!, this.passwordFormControl.value!, "ShouldNotBeRequired", "ShouldNotBeRequired")
        .subscribe(loginResponse => {
          this.localStorageService.saveData("accessToken", loginResponse.accessToken);
          this.router.navigate(['/homepage']).then(() => window.location.reload());
        });
    } else {
      console.error("Wrong password email combination.")
    }
  }

  loggedIn(): boolean {
    return this.localStorageService.getData("accessToken") != null;
  }
}
