import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { UserDto } from "../../user/dtos/user-dto";
import { Observable } from "rxjs";
import { UserFilterDto } from "../dtos/user-filter-dto";
import { SearchResultDto } from "../../app/generic/search-result-dto";

@Injectable({
  providedIn: "root",
})
export class UserService {
  private baseUrl = "http://localhost:12123/api/User";
  public currentUser: UserDto = new UserDto();

  constructor(private http: HttpClient) {}

  initializeUser(): Promise<{}> {
    return new Promise((resolve) => {
      return this.http
        .get<UserDto>("http://localhost:12123/api/User/CurrentUser")
        .subscribe((userData) => {
          this.currentUser = userData;
          resolve(true);
        });
    });
  }

  getAllwithFilter(userDto: UserFilterDto): Observable<SearchResultDto<UserDto>> {
    return this.http.get<SearchResultDto<UserDto>>(`${this.baseUrl}?${this.composeQueryString(userDto)}`);
  }


  composeQueryString(userDto: UserFilterDto): string {
    return Object.entries(userDto)
      .filter(([_, value]) => value !== null)
      .map(([key, value]) => `${key}=${value}`)
      .join("&");
  }
}
