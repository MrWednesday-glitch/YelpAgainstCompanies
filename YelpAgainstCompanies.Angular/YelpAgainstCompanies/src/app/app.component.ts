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
  user: User | undefined;
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
        console.log(data);
        this.titleService.setTitle(data['title']);
      })
    })
  }

  getChild(activatedRoute: ActivatedRoute): ActivatedRoute {
    if (activatedRoute.firstChild) {
      return this.getChild(activatedRoute.firstChild);
    } else {
      return activatedRoute;
    }
  }

  logOut = () => this.localStorageService.removeData("accessToken");

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
