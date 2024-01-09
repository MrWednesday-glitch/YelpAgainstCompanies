import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './components/homepage/homepage.component';
import { CompanyListComponent } from './components/company-list/company-list.component';
import { CompanyAndRatingsComponent } from './components/company-and-ratings/company-and-ratings.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { AddCompanyFormComponent } from './components/add-company-form/add-company-form.component';

const routes: Routes = [
  {path: "homepage", component: HomepageComponent, data: {title: "Homepage - Yelp Against Companies"}},
  {path: "", redirectTo: "/homepage", pathMatch: "full"},
  {path: "companies", component: CompanyListComponent, data: {title: "Companies - Yelp Against Companies"}},
  {path: "rating/:companyId", component:CompanyAndRatingsComponent, data: {title: "Company - Yelp Against Companies"}},
  {path: "register", component: RegisterFormComponent, data: {title: "Account registration - Yelp Against Companies"}},
  {path: "login", component: LoginFormComponent, data: {title: "Login - Yelp Against Companies"}},
  {path: "addcompany", component: AddCompanyFormComponent, data: {title: "Add a company - Yelp Against Companies"}},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
