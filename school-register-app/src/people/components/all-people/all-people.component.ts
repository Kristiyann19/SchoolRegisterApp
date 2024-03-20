import { Component } from "@angular/core";
import { PersonDto } from "../../dtos/person-dto";
import { PersonFilterDto } from "../../dtos/person-filter-dto";
import { PersonService } from "../../services/person.service";
import { catchError, throwError } from "rxjs";
import { SchoolService } from "../../../school/services/school.service";
import { ActivatedRoute } from "@angular/router";
import { UserService } from "../../../user/services/user.service";
import { SearchResultDto } from "../../../app/generic/search-result-dto";
import { RoleEnum, RoleEnumLocalization } from "../../../enums/role.enum";

@Component({
  selector: "app-all-people",
  templateUrl: "./all-people.component.html",
  styleUrl: "./all-people.component.css",
})
export class AllPeopleComponent {
  personDto: PersonFilterDto = new PersonFilterDto();
  searchResult: SearchResultDto<PersonDto> = new SearchResultDto<PersonDto>();
  pageSize = 3;
  page = 1;
  totalPeopleCount = 0;
  userRole: RoleEnum;
  constructor(public personService: PersonService, public schoolService: SchoolService, public userService: UserService) {}

  ngOnInit() {
    this.get(this.personDto);
  }

  get(personDto: PersonFilterDto) {
    this.personService
      .getAllWithFilter(personDto)
      .pipe(
        catchError((err) => { 
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.searchResult = res;
        this.totalPeopleCount = this.searchResult.totalCount;
      });
  }

  OnPageChange(newPage: number){
    this.personDto.page = newPage;
    this.get(this.personDto);
   }

}
