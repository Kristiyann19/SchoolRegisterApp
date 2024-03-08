import { Component } from "@angular/core";
import { LoginService } from "../../../login/services/login.service";
import { RegistrationService } from "../../../registration/services/registration.service";

@Component({
  selector: "app-nav",
  templateUrl: `./nav.component.html`,
  styleUrl: `./nav.component.css`,
})
export class NavComponent {
  constructor(
    public loginService: LoginService,
    public registrationService: RegistrationService
  ) {}
}
