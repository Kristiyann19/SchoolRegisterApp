import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { SettlementDto } from "../dtos/settlement-dto";

@Injectable({
  providedIn: "root",
})
export class SettlementService {
  private baseUrl = "http://localhost:12123/api/Settlement";

  constructor(private http: HttpClient) {}

  getAll(): Observable<SettlementDto[]> {
    return this.http.get<SettlementDto[]>(`${this.baseUrl}`);
  }
}
