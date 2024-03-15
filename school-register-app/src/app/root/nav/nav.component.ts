import { Component } from "@angular/core";
import { LoginService } from "../../../login/services/login.service";
import { UserService } from "../../../user/services/user.service";

@Component({
  selector: "app-nav",
  templateUrl: `./nav.component.html`,
  styleUrl: `./nav.component.css`,
})
export class NavComponent {
  constructor(
    public userService: UserService,
    public loginService: LoginService
  ) {}

  get isLoggedIn(): boolean {
    return this.loginService.getIsLoggedIn();
  }

logout(): void {
  this.loginService.logout(); 
  this.userService.initializeUser();
}
}
