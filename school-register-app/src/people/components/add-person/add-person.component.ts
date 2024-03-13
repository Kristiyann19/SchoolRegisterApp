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
}
