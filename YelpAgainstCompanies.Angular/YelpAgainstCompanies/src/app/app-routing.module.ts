import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './components/homepage/homepage.component';
import { CompanyListComponent } from './components/company-list/company-list.component';
import { CompanyAndRatingsComponent } from './components/company-and-ratings/company-and-ratings.component';

const routes: Routes = [
  {path: "homepage", component: HomepageComponent},
  {path: "", redirectTo: "/homepage", pathMatch: "full"},
  {path: "companies", component: CompanyListComponent},
  {path: "rating/:companyId", component:CompanyAndRatingsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
