import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { UserRegistrationDto } from "../../user/dtos/user-registration-dto";
import { Router } from "@angular/router";

@Injectable({
  providedIn: "root",
})
export class RegistrationService {
  private baseUrl = "http://localhost:12123/api/Register";

  constructor(private http: HttpClient) {}

  register(userDto: UserRegistrationDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}`, userDto);
  }

  checkUsernameAvailability(username: string) : Observable<boolean>{
    return this.http.get<boolean>(`${this.baseUrl}/check-username/${username}`);
}

  checkPhoneAvailability(phone: string) : Observable<boolean> {
    return this.http.get<boolean>(`${this.baseUrl}/check-phone/${phone}`)
}
}
