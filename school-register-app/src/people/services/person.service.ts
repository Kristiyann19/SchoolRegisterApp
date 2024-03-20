import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { PersonFilterDto } from "../dtos/person-filter-dto";
import { PersonDto } from "../dtos/person-dto";
import { PersonDetailsDto } from "../dtos/person-details-dto";
import { PersonAddDto } from "../dtos/person-add-dto";
import { GenderEnum } from "../../enums/gender.enum";
import { SearchResultDto } from "../../app/generic/search-result-dto";

@Injectable({
  providedIn: "root",
})
export class PersonService {
  private baseUrl = "http://localhost:12123/api/Person";

  constructor(private http: HttpClient) {}

  getAllWithFilter(personDto: PersonFilterDto): Observable<SearchResultDto<PersonDto>> {
    return this.http.get<SearchResultDto<PersonDto>>(`${this.baseUrl}?${this.composeQueryString(personDto)}` );
  }

  updatePerson(id: number, updatedPerson: PersonDetailsDto): Observable<any> {
    return this.http.put(this.baseUrl + `/${id}`, updatedPerson);
  }
  getById(id: number): Observable<PersonDetailsDto> {
    return this.http.get<PersonDetailsDto>(`${this.baseUrl}/${id}`);
  }

  add(personAddDto: PersonAddDto): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}`, personAddDto);
  }

  composeQueryString(personDto: PersonFilterDto): string {
    return Object.entries(personDto)
      .filter(([_, value]) => value !== null)
      .map(([key, value]) => `${key}=${value}`)
      .join("&");
  }

  public decodeUic(personAddDto: PersonAddDto) {
    const numberToSubtractFromMonth = 40;

    const bornBefore2000 = "19";
    const bornAfter2000 = "20";

    const lastTwoDigitsOfYear = personAddDto.uic.substring(0, 2);
    const monthDigits = personAddDto.uic.substring(2, 4);
    const dateDigits = personAddDto.uic.substring(4, 6);

    const firstDigitOfMonthDigits = monthDigits.substring(0, 1);

    let yearAsString = "";
    let monthAsString = "";
    let dateAsString = "";

    if (firstDigitOfMonthDigits === "4" || firstDigitOfMonthDigits === "5") {
      yearAsString = bornAfter2000 + lastTwoDigitsOfYear;

      const monthAsDigit = parseInt(monthDigits) - numberToSubtractFromMonth;
      monthAsString = monthAsDigit.toString();
    } else {
      yearAsString = bornBefore2000 + lastTwoDigitsOfYear;

      monthAsString = monthDigits.toString();
    }

    dateAsString = dateDigits.toString();

    const year = parseInt(yearAsString);
    const month = parseInt(monthAsString);
    const date = parseInt(dateAsString);

    const birthDate = new Date(year, month - 1, date);

    const digitForGender = parseInt(personAddDto.uic.substring(8, 9));

    const gender =
      digitForGender % 2 === 0 ? GenderEnum.male : GenderEnum.female;

    personAddDto.birthDate = birthDate;
    personAddDto.gender = gender;
  }
}
