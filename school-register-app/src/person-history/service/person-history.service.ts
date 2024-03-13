import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { PersonHistoryDto } from "../dtos/person-history.dto";

@Injectable({
  providedIn: "root",
})
export class PersonHistoryService {
  private baseUrl = "http://localhost:12123/api/PersonHistory";

  constructor(private http: HttpClient) {}

  getPersonHistoryById(id: number) : Observable<PersonHistoryDto[]> {
    return this.http.get<PersonHistoryDto[]>(this.baseUrl + `/${id}`);
  }
}
