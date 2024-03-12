import { Component } from "@angular/core";
import { UserDto } from "../../dtos/user-dto";
import { UserFilterDto } from "../../dtos/user-filter-dto";
import { UserService } from "../../services/user.service";
import { catchError, throwError } from "rxjs";

@Component({
  selector: "app-user",
  templateUrl: "./all-users.component.html",
  styleUrl: "./all-users.component.css",
})
export class AllUsersComponent {
  users: UserDto[] = [];
  userDto: UserFilterDto = new UserFilterDto();

  constructor(public userService: UserService) {}

  ngOnInit() {
    this.get();
  }

  get() {
    this.userService
      .getAll()
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.users = res;
      });
  }

  getFiltered(userDto: UserFilterDto) {
    this.userService
      .getFiltered(userDto)
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.users = res;
      });
  }
}
