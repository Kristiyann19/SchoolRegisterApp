import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { UserDto } from "../../user/dtos/user-dto";
import { UserLoginDto } from "../../user/dtos/user-login-dto";
import { Router } from "@angular/router";

@Injectable({
  providedIn: "root",
})
export class LoginService {
  private baseUrl = "http://localhost:12123";
  public currentUser: UserDto = new UserDto();

  constructor(private http: HttpClient, private router: Router) {}

  login(userDto: UserLoginDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/api/Login`, userDto);
  }

  logout(): Observable<void> {
    this.currentUser = null;
    localStorage.clear();
    this.router.navigate(["/login"]);
    return;
  }
}
