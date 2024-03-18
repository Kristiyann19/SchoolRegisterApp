import { Component, Input } from "@angular/core";
import { NgbActiveModal, NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { PersonSchoolAddDto } from "../../dtos/person-school-add-dto";
import { PersonSchoolService } from "../../service/person-school.service";
import { catchError, throwError } from "rxjs";

@Component({
  selector: "app-person-school-add-modal",
  templateUrl: `./person-school-add-modal.component.html`,
  styleUrl: `./person-school-add-modal.component.css`,
})
export class PersonSchoolAddModalComponent {
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
      .subscribe((res) => {
        this.activeModal.close();
      });
  }
}
