import { Component } from "@angular/core";
import { PersonDto } from "../../dtos/person-dto";
import { PersonFilterDto } from "../../dtos/person-filter-dto";
import { PersonService } from "../../services/person.service";
import { catchError, throwError } from "rxjs";
import { SettlementDto } from "../../../settlement/dtos/settlement-dto";

@Component({
  selector: "app-all-people",
  templateUrl: "./all-people.component.html",
  styleUrl: "./all-people.component.css",
})
export class AllPeopleComponent {
  people: PersonDto[] = [];
  personDto: PersonFilterDto = new PersonFilterDto();

  settlement: SettlementDto = new SettlementDto();

  constructor(public personService: PersonService) {}

  ngOnInit() {
    this.get();
  }

  get() {
    this.personService
      .getAll()
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.people = res;
      });
  }

  getFiltered(personDto: PersonFilterDto) {
    this.personService
      .getFiltered(personDto)
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.people = res;
      });
  }
}
