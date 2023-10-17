import { Component } from '@angular/core';
import { LocalStorageService } from './services/local-storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Yelp Against Companies';

  constructor(private localStorageService: LocalStorageService) {}

  logOut(): void {
    this.localStorageService.removeData("accessToken");
  }

  loggedIn(): boolean {
    return this.localStorageService.getData("accessToken") != null;
  }
}
