import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { PersonSchoolDto } from "../dtos/person-school.dto";
import { PositionEnumLocalization } from "../../enums/position.enum";
import { PersonSchoolService } from "../service/person-school.service";
import { catchError, throwError } from "rxjs";
import { SchoolService } from "../../school/all-schools/services/school.service";
import { SchoolDto } from "../../school/all-schools/dtos/school-dto";
import { PersonService } from "../../people/services/person.service";
import { PersonDetailsDto } from "../../people/dtos/person-details-dto";
import { AddDiscountModalContent } from "../modals/add-person-school-modal/add-person-school-modal.component";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: "app-person-school",
  templateUrl: "./person-school.component.html",
  styleUrl: "./person-school.component.css",
})
export class PersonSchoolComponent {
  personSchools: PersonSchoolDto[] = [];
  positionEnumLocalization = PositionEnumLocalization;
  person: PersonDetailsDto = new PersonDetailsDto();

  constructor(
    private personSchoolService: PersonSchoolService,
    private route: ActivatedRoute,
    private personService: PersonService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    const id = parseInt(this.route.snapshot.paramMap.get("id")!);
    this.personSchoolService
      .getPersonSchoolById(id)
      .subscribe((personSchools: PersonSchoolDto[]) => {
        this.personSchools = personSchools;
        this.getId();
      });
  }

  getId(): void {
    const id = parseInt(this.route.snapshot.paramMap.get("id")!);
    this.personService.getById(id).subscribe((person) => {
      this.person = { ...person };
    });
  }

  openAddPersonSchoolModal() {
    const modalRef = this.modalService.open(AddDiscountModalContent);
    modalRef.componentInstance.firstName = this.person.firstName;
    modalRef.componentInstance.lastName = this.person.lastName;
    modalRef.componentInstance.schoolName = this.person.school.name;
    modalRef.componentInstance.schoolId = this.person.school.id;
    modalRef.componentInstance.personId = this.person.id;
  }
}
