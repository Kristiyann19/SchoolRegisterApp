import { Component } from "@angular/core";
import { PersonService } from "../../services/person.service";
import { PersonDetailsDto } from "../../dtos/person-details-dto";
import { GenderEnumLocalization } from "../../../enums/gender.enum";
import { ActivatedRoute, Router } from "@angular/router";
import { SettlementDto } from "../../../settlement/dtos/settlement-dto";
import { catchError, throwError } from "rxjs";
import { SettlementService } from "../../../settlement/services/settlement.service";
import { SchoolService } from "../../../school/all-schools/services/school.service";
import { SchoolDto } from "../../../school/all-schools/dtos/school-dto";

@Component({
  selector: "app-details-person",
  templateUrl: "./details-person.component.html",
  styleUrl: "./details-person.component.css",
})
export class DetailsPersonComponent {

  genderEnumLocalization = GenderEnumLocalization;
  person: PersonDetailsDto = new PersonDetailsDto();
  settlements: SettlementDto[] = [];
  personId: number;

  school: SchoolDto
  schoolName: string;

  constructor(private route: ActivatedRoute, 
    public personService: PersonService, 
    private router: Router, 
    private settlementService: SettlementService,
    public schoolService: SchoolService) { }
  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.personId = +params['id'];
      this.fetchPersonDetails(); 
      this.getSettlements();
      
    });
  }


  fetchPersonDetails(): void {
    this.personService.getById(this.personId).subscribe((data) => {
      this.person = data; 
    });
  }

  updatePerson() : void {
    this.personService.updatePerson(this.personId, this.person).subscribe(() => {
      this.router.navigate(['/all-people'])
    })
  }


  // schoolNameById() : void {
  //   debugger;
  //   this.schoolService.schoolNameById(this.person.schoolId).subscribe((schoolData: any) => {
  //     this.schoolName = schoolData.name;
  //   })
  // }


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
