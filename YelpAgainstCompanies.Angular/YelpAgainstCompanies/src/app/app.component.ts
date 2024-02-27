import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from './services/local-storage.service';
import User from './interfaces/user';
import ProblemDetails from './interfaces/problem-details';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {

  title = 'Yelp Against Companies';
  firstNameUser: string | undefined;
  problemDetails: ProblemDetails | undefined

  constructor(private localStorageService: LocalStorageService, 
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private titleService: Title) { }

  ngOnInit(): void {
    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd),
      ).subscribe(() => {
        var rt = this.getChild(this.activatedRoute);

        rt.data.subscribe(data => {
          this.titleService.setTitle(data['title']);
        })
      })
    
      if (this.loggedIn()) {
        this.firstNameUser = this.localStorageService.getData("firstName")!;
        //TODO make a profile page that gets the necessary stuff via an api call with the username
        console.log(this.localStorageService.getData("userName"));
      }
  }

  getChild(activatedRoute: ActivatedRoute): ActivatedRoute {
    if (activatedRoute.firstChild) {
      return this.getChild(activatedRoute.firstChild);
    } else {
      return activatedRoute;
    }
  }

  logOut = () =>{
    this.localStorageService.removeData("accessToken");
    this.localStorageService.removeData("firstName");
  } 

  loggedIn(): boolean {
    return this.localStorageService.getData("accessToken") != null;
  }

  //TODO Have this be an "actual" profile picture
  showLoggedInImage(): string {
    if (this.loggedIn()) {
      return "https://thumbs.dreamstime.com/z/no-user-profile-picture-24185395.jpg";
    } else {
      return "https://cdn.onlinewebfonts.com/svg/img_333642.png";
    }
  }
}
