import { Component } from "@angular/core";
import { UserDto } from "../../dtos/user-dto";
import { UserFilterDto } from "../../dtos/user-filter-dto";
import { UserService } from "../../services/user.service";
import { catchError, throwError } from "rxjs";
import { SearchResultDto } from "../../../app/generic/search-result-dto";

@Component({
  selector: "app-user",
  templateUrl: "./all-users.component.html",
  styleUrl: "./all-users.component.css",
})
export class AllUsersComponent {
  users: UserDto[] = [];
  userDto: UserFilterDto = new UserFilterDto();
  searchResult: SearchResultDto<UserDto> = new SearchResultDto<UserDto>();
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
        this.searchResult = res;
        this.totalUsersCount = this.searchResult.totalCount;
      });
  }

  OnPageChange(newPage: number) {
    this.userDto.page = newPage;
    this.get(this.userDto);
  }
}
