import { Component, Input } from "@angular/core";
import { NgbActiveModal, NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { PersonSchoolAddDto } from "../../dtos/person-school-add-dto";

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

  constructor(public activeModal: NgbActiveModal) {}
}
