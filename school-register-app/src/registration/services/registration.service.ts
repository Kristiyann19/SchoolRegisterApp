import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Router } from "@angular/router";
import { UserRegistrationDto } from "../../user/dtos/user-registration-dto";

@Injectable({
  providedIn: "root",
})
export class RegistrationService {
  private baseUrl = "http://localhost:12123";

  constructor(private http: HttpClient, private router: Router) {}

  register(userDto: UserRegistrationDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}/api/Register`, userDto);
  }
}
