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
  pageSize = 5;
  page = 1;
  totalUsersCount = 0;
  constructor(public userService: UserService) {}

  ngOnInit() {
    this.get(this.userDto);
  }

  get(userDto: UserFilterDto) {
    this.userService
      .getAllwithFilter(userDto)
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.users = res;
        this.totalItems();
      });
  }

  totalItems() : void {
    this.userService.totalUsers().subscribe((count: number) =>{
        this.totalUsersCount = count;
   })
 }

OnPageChange(newPage: number){
  this.userDto.page = newPage;
  this.get(this.userDto);
 }

  // getFiltered(userDto: UserFilterDto) {
  //   this.userService
  //     .getFiltered(userDto)
  //     .pipe(
  //       catchError((err) => {
  //         return throwError(() => err);
  //       })
  //     )
  //     .subscribe((res) => {
  //       this.users = res;
  //     });
  // }
}
