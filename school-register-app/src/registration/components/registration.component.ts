import { Component } from "@angular/core";
import { UserRegistrationDto } from "../../user/dtos/user-registration-dto";
import { Router } from "@angular/router";
import { RegistrationService } from "../services/registration.service";
import { FormGroup } from "@angular/forms";

@Component({
  selector: "app-registration",
  templateUrl: "./registration.component.html",
  styleUrl: "./registration.component.css",
})
export class RegistrationComponent {
  //schools: SchoolDto[] = [];

  register: UserRegistrationDto = new UserRegistrationDto();
  form: FormGroup
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
  checkUsernameAvailability(): void{

    if(this.register.username){
      debugger;
      this.registerService.checkUsernameAvailability(this.register.username).subscribe(available => {
        if (!available){
          this.form.get('username').setErrors({'alreadyTaken' : true});
        }
      });
    }
   }
  
  //  checkPhoneAvailability() : void {
  //   const email = this.form.get('email').value;
  
  //   if (email) {
  //     this.registerService.checkEmailAvailability(email).subscribe(available => {
  //       if(!available){
  //         this.form.get('email').setErrors({'alreadyTaken' : true});
  //       }
  //     });
  //   }
  //  }
  
}
