import { Component } from "@angular/core";
import { catchError, throwError } from "rxjs";
import { SchoolDto } from "../../dtos/school-dto";
import { SchoolFilterDto } from "../../dtos/school-filter-dto";
import { SchoolService } from "../../services/school.service";
import {
  SchoolTypeEnum,
  SchoolTypeEnumLocalization,
} from "../../../enums/school-type.enum";
import { UserService } from "../../../user/services/user.service";
import { SearchResultDto } from "../../../app/generic/search-result-dto";

@Component({
  selector: "app-schools",
  templateUrl: "./all-schools.component.html",
  styleUrl: "./all-schools.component.css",
})
export class AllSchoolsComponent {
  schools: SchoolDto[] = [];
  school: SchoolFilterDto = new SchoolFilterDto();
  searchResult: SearchResultDto<SchoolDto> = new SearchResultDto<SchoolDto>();
  type = SchoolTypeEnum;

  pageSize = 5;
  page = 1;
  totalSchoolsCount = 0;
  schoolTypeEnumLocalization = SchoolTypeEnumLocalization;

  constructor(
    public schoolService: SchoolService,
    public userService: UserService
  ) {}

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
      this.searchResult = res;
      this.totalSchoolsCount = this.searchResult.totalCount;
    });
  }

   OnPageChange(newPage: number){
     this.school.page = newPage;
     this.get(this.school);
    }


}
