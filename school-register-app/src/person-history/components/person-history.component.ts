import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { catchError, throwError } from "rxjs";
import { PersonHistoryService } from "../service/person-history.service";
import { PersonHistoryDto } from "../dtos/person-history.dto";
import { ModificationTypeEnumLocalization } from "../../enums/modification-type.enum";
import { DataModifiedEnumLocalization } from "../../enums/data-modified.enum";
import { PersonService } from "../../people/services/person.service";
import { PersonDetailsDto } from "../../people/dtos/person-details-dto";

@Component({
  selector: "app-person-history",
  templateUrl: "./person-history.component.html",
  styleUrl: "./person-history.component.css",
})
export class PersonHistoryComponent {
  personHistories: PersonHistoryDto[] = [];
  person: PersonDetailsDto = new PersonDetailsDto;
  personId: number;
  personHistory: PersonHistoryDto = new PersonHistoryDto();
  modificationTypeEnumLocalization = ModificationTypeEnumLocalization;
  dataModifiedEnumLocalization = DataModifiedEnumLocalization;

  constructor (private personHistoryService: PersonHistoryService, private route: ActivatedRoute, private personService: PersonService) {}

  ngOnInit (): void{
    const id = parseInt(this.route.snapshot.paramMap.get('id')!)
    this.personHistoryService.getPersonHistoryById(id).subscribe((personHistories: PersonHistoryDto[]) => {
      this.personHistories = personHistories;
    this.get();
    })
  } 

  get() : void {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!)
    this.personService.getById(id).subscribe((person) => {
      this.person = { ...person }; 
    });
  }
}
