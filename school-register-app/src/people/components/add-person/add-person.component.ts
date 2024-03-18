import { Component } from "@angular/core";
import { SettlementService } from "../../../settlement/services/settlement.service";
import { catchError, throwError } from "rxjs";
import { SettlementDto } from "../../../settlement/dtos/settlement-dto";
import { PersonAddDto } from "../../dtos/person-add-dto";
import { PersonService } from "../../services/person.service";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";

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
    private router: Router,
    private toastr: ToastrService
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
        console.log(this.settlements);
      });
  }

  addPerson(personAddDto: PersonAddDto) {
    this.personService
      .add(personAddDto)
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )

      .subscribe(() => {
        this.toastr.success("Добавено");
        this.router.navigate(["/all-people"]);
      });
  }
}
