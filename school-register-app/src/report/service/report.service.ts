import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ReportDto } from "../dtos/report.dto";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class ReportService {
  private baseUrl = "http://localhost:12123/api/Report";

  constructor(private http: HttpClient) {}

  getReport(report: ReportDto) : Observable<ReportDto[]> {
    return this.http.get<ReportDto[]>(this.baseUrl);
  }
}
