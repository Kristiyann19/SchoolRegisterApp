import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { PersonFilterDto } from "../dtos/person-filter-dto";
import { PersonDto } from "../dtos/person-dto";

@Injectable({
  providedIn: "root",
})
export class PersonService {
  private baseUrl = "http://localhost:12123/api/Person";

  constructor(private http: HttpClient) {}

  getAll(): Observable<PersonDto[]> {
    return this.http.get<PersonDto[]>(`${this.baseUrl}`);
  }

  getFiltered(personDto: PersonFilterDto): Observable<PersonDto[]> {
    return this.http.get<PersonDto[]>(
      `${this.baseUrl}/Filter?${this.composeQueryString(personDto)}`
    );
  }

  composeQueryString(personDto: PersonFilterDto): string {
    return Object.entries(personDto)
      .filter(([_, value]) => value !== null)
      .map(([key, value]) => `${key}=${value}`)
      .join("&");
  }
}
