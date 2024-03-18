import { Component } from "@angular/core";
import { catchError, throwError } from "rxjs";
import { SchoolDto } from "../dtos/school-dto";
import { SchoolFilterDto } from "../dtos/school-filter-dto";
import { SchoolService } from "../services/school.service";
import {
  SchoolTypeEnum,
  SchoolTypeEnumLocalization,
} from "../../../enums/school-type.enum";

@Component({
  selector: "app-schools",
  templateUrl: "./all-schools.component.html",
  styleUrl: "./all-schools.component.css",
})
export class AllSchoolsComponent {
  schools: SchoolDto[] = [];
  school: SchoolFilterDto = new SchoolFilterDto();

  type = SchoolTypeEnum;

  pageSize = 5;
  page = 1;
  totalSchoolsCount = 0;
  schoolTypeEnumLocalization = SchoolTypeEnumLocalization;

  constructor(public schoolService: SchoolService) {}

  ngOnInit() {
    this.get(this.school);
  }

  get(school: SchoolFilterDto) {
    this.schoolService.getAllwithFilter(school).pipe(
      catchError((err) => { 
        return throwError(() => err);
      })
    )
    .subscribe((res) => {
      this.schools = res;
      this.totalItems()
    });
  }

  totalItems() : void {
       this.schoolService.totalSchools().subscribe((count: number) =>{
           this.totalSchoolsCount = count;
      })
    }

   OnPageChange(newPage: number){
     this.school.page = newPage;
     this.get(this.school);
    }

}
