import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from './services/local-storage.service';
import { UserService } from './services/user.service';
import User from './interfaces/user';
import ProblemDetails from './interfaces/problem-details';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit{

  title = 'Yelp Against Companies';
  user: User | undefined;
  problemDetails: ProblemDetails | undefined

  constructor(private localStorageService: LocalStorageService, private userService: UserService) { }

  ngOnInit(): void {
    if (this.localStorageService.getData("accessToken") != null) {
      this.userService.getUser()
        .subscribe({
          next: (u) => {
            this.user = u;
          },
          error: (err) => {
            this.problemDetails = err.error;

            if (this.problemDetails) {
              this.localStorageService.clearData();
            }
          }
        })
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
