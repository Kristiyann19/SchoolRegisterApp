import { Component, Input } from "@angular/core";
import { NgbActiveModal, NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { PersonSchoolAddDto } from "../../dtos/person-school-add-dto";
import { PersonSchoolService } from "../../service/person-school.service";
import { catchError, throwError } from "rxjs";

@Component({
  selector: "add-address-modal-content",
  templateUrl: `./add-person-school-modal.component.html`,
  styleUrl: `./add-person-school-modal.component.html`,
})
export class AddDiscountModalContent {
  personSchoolAddDto: PersonSchoolAddDto = new PersonSchoolAddDto();

  @Input() firstName: string;
  @Input() lastName: string;
  @Input() schoolName: string;
  @Input() schoolId: number;
  @Input() personId: number;

  constructor(
    public activeModal: NgbActiveModal,
    public personSchoolService: PersonSchoolService
  ) {}

  add() {
    this.personSchoolAddDto.personId = this.personId;
    this.personSchoolAddDto.schoolId = this.schoolId;

    this.personSchoolService
      .addPersonSchool(this.personSchoolAddDto)
      .pipe(
        catchError((err) => {
          return throwError(() => err);
        })
      )
      .subscribe((res) => {});
  }
}
