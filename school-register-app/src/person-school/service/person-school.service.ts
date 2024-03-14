import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { PersonSchoolDto } from "../dtos/person-school.dto";
import { PersonSchoolAddDto } from "../dtos/person-school-add-dto";

@Injectable({
  providedIn: "root",
})
export class PersonSchoolService {
  private baseUrl = "http://localhost:12123/api/PersonSchool";

  constructor(private http: HttpClient) {}

  getPersonSchoolById(id: number): Observable<PersonSchoolDto[]> {
    return this.http.get<PersonSchoolDto[]>(this.baseUrl + `/${id}`);
  }

  add(personSchoolDto: PersonSchoolAddDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}`, personSchoolDto);
  }
}
