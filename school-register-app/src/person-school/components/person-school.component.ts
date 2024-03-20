import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { PersonSchoolDto } from "../dtos/person-school.dto";
import { PositionEnumLocalization } from "../../enums/position.enum";
import { PersonSchoolService } from "../service/person-school.service";
import { PersonService } from "../../people/services/person.service";
import { PersonDetailsDto } from "../../people/dtos/person-details-dto";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { UserService } from "../../user/services/user.service";
import { PersonSchoolAddModalComponent } from "../modals/person-school-add-modal/person-school-add-modal.component";
import { PersonSchoolUpdateDto } from "../dtos/person-school-update-dto";
import { catchError, throwError } from "rxjs";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-person-school",
  templateUrl: "./person-school.component.html",
  styleUrl: "./person-school.component.css",
})
export class PersonSchoolComponent {
  personSchools: PersonSchoolDto[] = [];
  positionEnumLocalization = PositionEnumLocalization;
  person: PersonDetailsDto = new PersonDetailsDto();
  personSchoolUpdateDto: PersonSchoolUpdateDto = new PersonSchoolUpdateDto();

  constructor(
    private personSchoolService: PersonSchoolService,
    private route: ActivatedRoute,
    private personService: PersonService,
    private modalService: NgbModal,
    private userService: UserService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getPersonSchools();
  }

  getPersonSchools(): void {
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
    const modalRef = this.modalService.open(PersonSchoolAddModalComponent);
    modalRef.componentInstance.firstName = this.person.firstName;
    modalRef.componentInstance.lastName = this.person.lastName;
    modalRef.componentInstance.schoolName =
      this.userService.currentUser.school.name;
    modalRef.componentInstance.schoolId =
      this.userService.currentUser.school.id;
    modalRef.componentInstance.personId = this.person.id;
  }

  update(personSchoolDto: PersonSchoolDto) {
    this.personSchoolUpdateDto.id = personSchoolDto.id;
    this.personSchoolUpdateDto.position = personSchoolDto.position;
    this.personSchoolUpdateDto.personId = personSchoolDto.personId;
    this.personSchoolUpdateDto.schoolId = personSchoolDto.schoolId;
    this.personSchoolUpdateDto.startDate = personSchoolDto.startDate;
    this.personSchoolUpdateDto.endDate = personSchoolDto.endDate;

    this.personSchoolService
      .updatePersonSchool(this.personSchoolUpdateDto)
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {
        this.toastr.success("Променено");
      });
  }
}
