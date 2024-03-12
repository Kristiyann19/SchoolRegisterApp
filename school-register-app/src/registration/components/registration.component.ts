import { Component } from "@angular/core";
import { UserRegistrationDto } from "../../user/dtos/user-registration-dto";
import { Router } from "@angular/router";
import { RegistrationService } from "../services/registration.service";

@Component({
  selector: "app-registration",
  templateUrl: "./registration.component.html",
  styleUrl: "./registration.component.css",
})
export class RegistrationComponent {
  //schools: SchoolDto[] = [];

  register: UserRegistrationDto = new UserRegistrationDto();

  constructor(
    private registerService: RegistrationService,
    private router: Router
  ) {}
  onRegister(): void {
    this.registerService.register(this.register).subscribe(
      () => {
        console.log("User registered successfuly");
        this.router.navigate(["/login"]);
      },
      (error) => {
        console.error("Register failed.", error);
      }
    );
  }
}
