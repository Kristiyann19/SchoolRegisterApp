import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { PersonSchoolDto } from "../dtos/person-school.dto";
import { PositionEnumLocalization } from "../../enums/position.enum";
import { PersonSchoolService } from "../service/person-school.service";
import { SettlementService } from "../../settlement/services/settlement.service";
import { catchError, throwError } from "rxjs";
import { SettlementDto } from "../../settlement/dtos/settlement-dto";
import { SchoolService } from "../../school/all-schools/services/school.service";
import { SchoolDto } from "../../school/all-schools/dtos/school-dto";
import { PersonService } from "../../people/services/person.service";
import { PersonDto } from "../../people/dtos/person-dto";
import { PersonDetailsDto } from "../../people/dtos/person-details-dto";

@Component({
  selector: "app-person-school",
  templateUrl: "./person-school.component.html",
  styleUrl: "./person-school.component.css",
})
export class PersonSchoolComponent {
  personSchools: PersonSchoolDto[] = [];
  positionEnumLocalization = PositionEnumLocalization;
  schools: SchoolDto[] = [];
  person: PersonDetailsDto = new PersonDetailsDto();

  constructor(
    private personSchoolService: PersonSchoolService,
    private route: ActivatedRoute,
    private schoolService: SchoolService,
    private personService: PersonService
  ) {}

  ngOnInit(): void {
    const id = parseInt(this.route.snapshot.paramMap.get("id")!);
    this.personSchoolService
      .getPersonSchoolById(id)
      .subscribe((personSchools: PersonSchoolDto[]) => {
        this.personSchools = personSchools;
        this.get();
        this.getId();
      });
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

  getId(): void {
    const id = parseInt(this.route.snapshot.paramMap.get("id")!);
    this.personService.getById(id).subscribe((person) => {
      this.person = { ...person };
    });
  }
}
