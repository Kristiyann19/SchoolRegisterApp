import { Component, OnInit } from "@angular/core";
import { UserRegistrationDto } from "../../user/dtos/user-registration-dto";
import { Router } from "@angular/router";
import { RegistrationService } from "../services/registration.service";
import { FormGroup } from "@angular/forms";
import { SchoolDto } from "../../school/all-schools/dtos/school-dto";
import { SchoolService } from "../../school/all-schools/services/school.service";
import { catchError, throwError } from "rxjs";

@Component({
  selector: "app-registration",
  templateUrl: "./registration.component.html",
  styleUrl: "./registration.component.css",
})
export class RegistrationComponent {
  schools: SchoolDto[] = [];

  register: UserRegistrationDto = new UserRegistrationDto();
  form: FormGroup;

  constructor(
    private registerService: RegistrationService,
    private schoolService: SchoolService,
    private router: Router
  ) {}

  ngOnInit() {
    this.getSchools();
  }

  getSchools() {
    this.schoolService
      .getAll()
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        debugger;
        this.schools = res;
      });
  }

  onRegister(): void {
    debugger;
    this.registerService.register(this.register).subscribe(
      (form) => {
        form = form;
        console.log("User registered successfuly");
        this.router.navigate(["/login"]);
      },
      (error) => {
        console.error("Register failed.", error);
      }
    );
  }

  checkUsernameAvailability(): void{
    debugger;
    if(this.register.username){
      debugger;
      this.registerService.checkUsernameAvailability(this.register.username).subscribe(available => {
        if (!available){
          //TODO:
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
