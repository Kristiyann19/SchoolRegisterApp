import { Component } from "@angular/core";
import { catchError, throwError } from "rxjs";
import { SchoolService } from "../../services/school.service";
import { AddSchoolDto } from "../../dtos/school-add";
import { SchoolTypeEnumLocalization } from "../../../enums/school-type.enum";
import { SettlementDto } from "../../../settlement/dtos/settlement-dto";
import { SettlementService } from "../../../settlement/services/settlement.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-add-school",
  templateUrl: "./add-school.component.html",
  styleUrl: "./add-school.component.css",
})
export class AddSchoolComponent {
  settlements: SettlementDto[] = [];
  addSchool : AddSchoolDto = new AddSchoolDto();
  schoolTypeEnumLocalization = SchoolTypeEnumLocalization
  constructor(public schoolService: SchoolService, private settlementService: SettlementService, private router: Router) {}

  ngOnInit() {
    this.getSettlements();
  }


  add(addSchool : AddSchoolDto) {
    this.schoolService.addSchool(addSchool)
    .pipe(
      catchError((err) => {
        return throwError(() => err);
      })
    )
    .subscribe((res) => {
      this.router.navigate(["all-schools"])
    });
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
