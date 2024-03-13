import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { PersonSchoolDto } from "../dtos/person-school.dto";
import { PositionEnumLocalization } from "../../enums/position.enum";
import { PersonSchoolService } from "../service/person-school.service";
import { SettlementService } from "../../settlement/services/settlement.service";
import { catchError, throwError } from "rxjs";
import { SettlementDto } from "../../settlement/dtos/settlement-dto";

@Component({
  selector: "app-person-school",
  templateUrl: "./person-school.component.html",
  styleUrl: "./person-school.component.css",
})
export class PersonSchoolComponent {
  personSchools: PersonSchoolDto[] = [];
  positionEnumLocalization = PositionEnumLocalization;
  settlements: SettlementDto[] = [];

  constructor (private personSchoolService: PersonSchoolService, private route: ActivatedRoute, private settlementService: SettlementService) {}

  ngOnInit (): void{
    const id = parseInt(this.route.snapshot.paramMap.get('id')!)
    this.personSchoolService.getPersonSchoolById(id).subscribe((personSchools: PersonSchoolDto[]) => {
      this.personSchools = personSchools;
      this.getSettlements();
    })
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
}
