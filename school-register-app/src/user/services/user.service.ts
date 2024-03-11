import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { UserDto } from "../../user/dtos/user-dto";

@Injectable({
  providedIn: "root",
})
export class UserService {
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
}
