import { Component } from "@angular/core";
import { LoginService } from "../../services/login.service";
import { Router } from "@angular/router";
import { UserLoginDto } from "../../../user/dtos/user-login-dto";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrl: "./login.component.css",
})
export class LoginComponent {
  loginDto: UserLoginDto = new UserLoginDto();

  constructor(private loginService: LoginService, private router: Router) {}

  onSubmit() {
    this.loginService.login(this.loginDto).subscribe((response: any) => {
      if (response?.token) {
        localStorage.setItem("token", response.token);
        this.loginService.initializeUser();
        this.router.navigate(["/"]);
      }
    });
  }
}
