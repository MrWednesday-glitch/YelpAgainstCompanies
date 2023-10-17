import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './components/homepage/homepage.component';
import { CompanyListComponent } from './components/company-list/company-list.component';
import { CompanyAndRatingsComponent } from './components/company-and-ratings/company-and-ratings.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { AddCompanyFormComponent } from './components/add-company-form/add-company-form.component';

const routes: Routes = [
  {path: "homepage", component: HomepageComponent},
  {path: "", redirectTo: "/homepage", pathMatch: "full"},
  {path: "companies", component: CompanyListComponent},
  {path: "rating/:companyId", component:CompanyAndRatingsComponent},
  {path: "register", component: RegisterFormComponent},
  {path: "login", component: LoginFormComponent},
  {path: "addcompany", component: AddCompanyFormComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
