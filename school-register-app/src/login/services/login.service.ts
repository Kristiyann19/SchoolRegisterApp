import { Inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { UserDto } from "../../user/dtos/user-dto";
import { UserLoginDto } from "../../user/dtos/user-login-dto";
import { Router } from "@angular/router";
import { DOCUMENT } from "@angular/common";

@Injectable({
  providedIn: "root",
})
export class LoginService {
  private baseUrl = "http://localhost:12123";
  public currentUser: UserDto = new UserDto();
  public isLoggedIn = false;

  localStorage: Storage;

  constructor(private http: HttpClient, private router: Router, @Inject(DOCUMENT) private document: Document,) {
    this.localStorage = document.defaultView?.localStorage;
  }

  login(userDto: UserLoginDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/api/Login`, userDto);
  }

  logout() {
    this.currentUser = null;
    this.localStorage?.clear();
    this.setIsLoggedIn(false);
    this.router.navigate(["/login"]);
  }

  setIsLoggedIn(status: boolean): void {
    this.isLoggedIn = this.localStorage?.getItem('access_token') ? true : false;
    this.isLoggedIn = status; 
  }

  getIsLoggedIn(): boolean {
    this.isLoggedIn = this.localStorage?.getItem('access_token') ? true : false;
    return this.isLoggedIn; 
  }
}
