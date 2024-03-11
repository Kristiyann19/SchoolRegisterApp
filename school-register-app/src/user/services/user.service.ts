import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { UserDto } from "../../user/dtos/user-dto";
import { Observable } from "rxjs";
import { UserFilterDto } from "../dtos/user-filter-dto";

@Injectable({
  providedIn: "root",
})
export class UserService {
  private baseUrl = "http://localhost:12123";
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

  getAll(): Observable<UserDto[]> {
    return this.http.get<UserDto[]>(`${this.baseUrl}/api/User`);
  }

  getFiltered(userDto: UserFilterDto): Observable<UserDto[]> {
    return this.http.get<UserDto[]>(
      `${this.baseUrl}/api/User/Filter?${this.composeQueryString(userDto)}`
    );
  }

  composeQueryString(userDto: UserFilterDto): string {
    return Object.entries(userDto)
      .filter(([_, value]) => value !== null)
      .map(([key, value]) => `${key}=${value}`)
      .join("&");
  }
}
