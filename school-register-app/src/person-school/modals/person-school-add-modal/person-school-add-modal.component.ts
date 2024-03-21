import { Component, Input } from "@angular/core";
import { NgbActiveModal, NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { PersonSchoolAddDto } from "../../dtos/person-school-add-dto";
import { PersonSchoolService } from "../../service/person-school.service";
import { catchError, throwError } from "rxjs";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { NgModel } from "@angular/forms";

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

  today = new Date();

  constructor(
    public activeModal: NgbActiveModal,
    public personSchoolService: PersonSchoolService,
    private router: Router,
    private toastr: ToastrService
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
        this.toastr.success("Успешно добавена длъжност");
      });
  }

  isDateValid(chosenDateInput: NgModel): boolean {
    const chosenDate: Date = new Date(chosenDateInput.value);

    // Check if the date is a valid Date object
    if (isNaN(chosenDate.getTime())) {
      return false;
    }

    // Check if the chosen date is after the current date
    const isAfterToday = chosenDate > this.today;

    // Additional check for expiration date to be after the start date
    if (chosenDateInput.name === "expirationDateInput") {
      const startDate: Date = new Date(this.personSchoolAddDto.startDate);
      return isAfterToday && chosenDate > startDate;
    }

    return isAfterToday;
  }
}
