import { Component, OnInit } from "@angular/core";
import { UserRegistrationDto } from "../../user/dtos/user-registration-dto";
import { Router } from "@angular/router";
import { RegistrationService } from "../services/registration.service";
import { FormGroup } from "@angular/forms";
import { SchoolDto } from "../../school/dtos/school-dto";
import { SchoolService } from "../../school/services/school.service";
import { catchError, throwError } from "rxjs";
import { ToastrService } from "ngx-toastr";
import { SchoolFilterDto } from "../../school/dtos/school-filter-dto";
import { InputLengthMax, InputLengthMin, PhoneRegex } from "../../app/common/validation-consts";

@Component({
  selector: "app-registration",
  templateUrl: "./registration.component.html",
  styleUrl: "./registration.component.css",
})
export class RegistrationComponent {
  schools: SchoolDto[] = [];
  school: SchoolFilterDto = new SchoolFilterDto();
  register: UserRegistrationDto = new UserRegistrationDto();
  form: FormGroup;

  nameMinLength = InputLengthMin;
  nameMaxLength = InputLengthMax;
  phoneRegex = PhoneRegex;
  
  constructor(
    private registerService: RegistrationService,
    private schoolService: SchoolService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.getSchools();
  }

  getSchools() {
    this.schoolService
      .allSchools()
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.schools = res;
      });
  }

  onRegister(): void {
    this.registerService.register(this.register).subscribe(
      (form) => {
        form = form;
        this.toastr.success("Успешна регистрация");
        this.router.navigate(["/login"]);
      },
      (error) => {
        return throwError(() => error);
      }
    );
  }

  checkUsernameAvailability(): void {
    if (this.register.username) {
      this.registerService
        .checkUsernameAvailability(this.register.username)
        .pipe(
          catchError((err) => {
            return throwError(() => err);
          })
        )
        .subscribe();
    }
  }

  checkPhoneAvailability(): void {
    if (this.register.phone) {
      this.registerService
        .checkPhoneAvailability(this.register.phone)
        .pipe(
          catchError((err) => {
            return throwError(() => err);
          })
        )
        .subscribe();
    }
  }
}
