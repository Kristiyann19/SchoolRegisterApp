import { Component } from "@angular/core";
import { SettlementService } from "../../../settlement/services/settlement.service";
import { catchError, throwError } from "rxjs";
import { SettlementDto } from "../../../settlement/dtos/settlement-dto";
import { PersonAddDto } from "../../dtos/person-add-dto";
import { PersonService } from "../../services/person.service";
import { GenderEnum } from "../../../enums/gender.enum";

@Component({
  selector: "app-add-person",
  templateUrl: "./add-person.component.html",
  styleUrl: "./add-person.component.css",
})
export class AddPersonComponent {
  settlements: SettlementDto[] = [];
  personAddDto: PersonAddDto = new PersonAddDto();

  constructor(
    public settlementService: SettlementService,
    public personService: PersonService
  ) {}

  ngOnInit() {
    this.getSettlements();
  }

  getSettlements() {
    this.settlementService
      .getAll()
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.settlements = res;
      });
  }

  add(personAddDto: PersonAddDto) {
    this.personService
      .add(personAddDto)
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {});
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
    const month = parseInt(monthAsString.replace("0", ""));
    const date = parseInt(dateAsString.replace("0", ""));

    const birthDate = new Date(year, month - 1, date);

    const digitForGender = parseInt(personAddDto.uic.substring(8, 10));

    const gender =
      digitForGender % 2 === 0 ? GenderEnum.male : GenderEnum.female;

    personAddDto.birthDate = birthDate;
    personAddDto.gender = gender;
  }
}
