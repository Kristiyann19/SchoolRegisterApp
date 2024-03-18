import { Component } from "@angular/core";
import { SettlementService } from "../../../settlement/services/settlement.service";
import { catchError, throwError } from "rxjs";
import { SettlementDto } from "../../../settlement/dtos/settlement-dto";
import { PersonAddDto } from "../../dtos/person-add-dto";
import { PersonService } from "../../services/person.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-add-person",
  templateUrl: "./add-person.component.html",
  styleUrl: "./add-person.component.css",
})
export class AddPersonComponent {
  settlements: SettlementDto[] = [];
  personAddDto: PersonAddDto = new PersonAddDto();

  constructor(
    private settlementService: SettlementService,
    public personService: PersonService,

    private router: Router
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

  addPerson(personAddDto: PersonAddDto) {
    debugger;
    this.personService
      .add(personAddDto)
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe(() => { });
  }
}
