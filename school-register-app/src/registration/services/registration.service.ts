import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { UserRegistrationDto } from "../../user/dtos/user-registration-dto";
@Injectable({
  providedIn: "root",
})
export class RegistrationService {
  private baseUrl = "http://localhost:12123/api/Register";

  constructor(private http: HttpClient) {}

  register(userDto: UserRegistrationDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}`, userDto);
  }

  checkUsernameAvailability(username: string): Observable<void> {
    const params = { username: username };
    return this.http.get<void>(`${this.baseUrl}/check-username?`, {
      params: params,
    });
  }

  checkPhoneAvailability(phone: string): Observable<void> {
    const params = { phone: phone };
    return this.http.get<void>(`${this.baseUrl}/check-phone`, {
      params: params,
    });
  }
}
