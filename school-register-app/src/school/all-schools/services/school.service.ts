import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { SchoolDto } from "../dtos/school-dto";
import { SchoolFilterDto } from "../dtos/school-filter-dto";
import { AddSchoolDto } from "../dtos/school-add";

@Injectable({
  providedIn: "root",
})
export class SchoolService {
  private baseUrl = "http://localhost:12123/api/School";

  constructor(private http: HttpClient) {}

  getAllwithFilter(schoolDto: SchoolFilterDto): Observable<SchoolDto[]> {
    return this.http.get<SchoolDto[]>(`${this.baseUrl}?${this.composeQueryString(schoolDto)}`);
  }

  addSchool(addSchool: AddSchoolDto): Observable<AddSchoolDto> {
    return this.http.post<AddSchoolDto>(this.baseUrl, addSchool);
  }

  totalSchools() : Observable<number> {
    return this.http.get<number>(this.baseUrl + '/Count');
  }

  composeQueryString(schoolDto: SchoolFilterDto): string {
    return Object.entries(schoolDto)
      .filter(([_, value]) => value !== null)
      .map(([key, value]) => `${key}=${value}`)
      .join("&");
  }
}
