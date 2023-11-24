import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { HomepageComponent } from './components/homepage/homepage.component';
import { CompanyListComponent } from './components/company-list/company-list.component';
import { CompanyListItemComponent } from './components/company-list-item/company-list-item.component';
import { HttpClientModule } from '@angular/common/http';
import { CompanyAndRatingsComponent } from './components/company-and-ratings/company-and-ratings.component';
import { RatingListItemComponent } from './components/rating-list-item/rating-list-item.component';
import { MatCardModule } from '@angular/material/card';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { MatInputModule } from '@angular/material/input'; 
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddCompanyFormComponent } from './components/add-company-form/add-company-form.component';
import { MatMenuModule } from '@angular/material/menu';
import { MatDividerModule } from '@angular/material/divider';
import { AddRatingFormComponent } from './components/add-rating-form/add-rating-form.component';
import { MatSelectModule } from '@angular/material/select'; 
import { MatExpansionModule } from '@angular/material/expansion'; 
import {MatButtonModule} from '@angular/material/button';

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    CompanyListComponent,
    CompanyListItemComponent,
    CompanyAndRatingsComponent,
    RatingListItemComponent,
    RegisterFormComponent,
    LoginFormComponent,
    AddCompanyFormComponent,
    AddRatingFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatSidenavModule,
    HttpClientModule,
    MatCardModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatMenuModule,
    MatDividerModule,
    MatSelectModule,
    MatExpansionModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
