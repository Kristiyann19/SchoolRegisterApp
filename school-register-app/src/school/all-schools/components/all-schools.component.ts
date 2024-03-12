import { Component } from "@angular/core";
import { catchError, throwError } from "rxjs";
import { SchoolDto } from "../dtos/school-dto";
import { SchoolFilterDto } from "../dtos/school-filter-dto";
import { SchoolService } from "../services/school.service";
import { SchoolTypeEnum, SchoolTypeEnumLocalization } from "../../../enums/school-type.enum";

@Component({
  selector: "app-user",
  templateUrl: "./all-schools.component.html",
  styleUrl: "./all-schools.component.css",
})
export class AllSchoolsComponent {
  schools: SchoolDto[] = [];
  school: SchoolFilterDto = new SchoolFilterDto();

  type = SchoolTypeEnum;
  schoolTypeEnumLocalization = SchoolTypeEnumLocalization;

  constructor(public schoolService: SchoolService) {}

  ngOnInit() {
    this.get();
  }

  get() {
    this.schoolService
      .getAll()
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.schools = res;
      });
  }

  getFiltered(school: SchoolFilterDto) {
    this.schoolService
      .getFiltered(school)
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.schools = res;
      });
  }
}
