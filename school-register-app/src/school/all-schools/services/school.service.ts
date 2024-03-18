import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { SchoolDto } from "../dtos/school-dto";
import { SchoolFilterDto } from "../dtos/school-filter-dto";
import { PersonDetailsDto } from "../../../people/dtos/person-details-dto";
import { AddSchoolDto } from "../dtos/school-add";

@Injectable({
  providedIn: "root",
})
export class SchoolService {
  private baseUrl = "http://localhost:12123/api/School";

  constructor(private http: HttpClient) {}

  getAll(): Observable<SchoolDto[]> {
    return this.http.get<SchoolDto[]>(`${this.baseUrl}`);
  }

  addSchool(addSchool: AddSchoolDto) : Observable<AddSchoolDto> {
    return this.http.post<AddSchoolDto>(this.baseUrl, addSchool)
  }
  schoolNameById(id: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/SchoolId/${id}`);
  }

  getFiltered(schoolDto: SchoolFilterDto): Observable<SchoolDto[]> {
    return this.http.get<SchoolDto[]>(
      `${this.baseUrl}/Search?${this.composeQueryString(schoolDto)}`
    );
  }

  composeQueryString(schoolDto: SchoolFilterDto): string {
    return Object.entries(schoolDto)
      .filter(([_, value]) => value !== null)
      .map(([key, value]) => `${key}=${value}`)
      .join("&");
  }
}
