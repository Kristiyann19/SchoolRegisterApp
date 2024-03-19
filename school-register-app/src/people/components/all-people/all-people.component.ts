import { Component } from "@angular/core";
import { PersonDto } from "../../dtos/person-dto";
import { PersonFilterDto } from "../../dtos/person-filter-dto";
import { PersonService } from "../../services/person.service";
import { catchError, throwError } from "rxjs";
import { SettlementDto } from "../../../settlement/dtos/settlement-dto";
import { SchoolService } from "../../../school/services/school.service";
import { ActivatedRoute } from "@angular/router";
import { UserService } from "../../../user/services/user.service";

@Component({
  selector: "app-all-people",
  templateUrl: "./all-people.component.html",
  styleUrl: "./all-people.component.css",
})
export class AllPeopleComponent {
  people: PersonDto[] = [];
  personDto: PersonFilterDto = new PersonFilterDto();
  schoolId: number;
  settlement: SettlementDto = new SettlementDto();
  schoolName: string;

  pageSize = 3;
  page = 1;
  totalPeopleCount = 0;

  constructor(public personService: PersonService, public schoolService: SchoolService, private route: ActivatedRoute, public userService: UserService) {}

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
        this.people = res;
        this.totalItems()
      });
  }

  totalItems() : void {
    this.personService.totalPeople().subscribe((count: number) =>{
        this.totalPeopleCount = count;
    })
  }

  OnPageChange(newPage: number){
    this.personDto.page = newPage;
    this.get(this.personDto);
   }

}
