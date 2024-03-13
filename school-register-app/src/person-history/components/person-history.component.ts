import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { catchError, throwError } from "rxjs";
import { PersonHistoryService } from "../service/person-history.service";
import { PersonHistoryDto } from "../dtos/person-history.dto";
import { ModificationTypeEnumLocalization } from "../../enums/modification-type.enum";
import { DataModifiedEnumLocalization } from "../../enums/data-modified.enum";

@Component({
  selector: "app-person-history",
  templateUrl: "./person-history.component.html",
  styleUrl: "./person-history.component.css",
})
export class PersonHistoryComponent {
  personHistories: PersonHistoryDto[] = [];

  personHistory: PersonHistoryDto = new PersonHistoryDto();
  modificationTypeEnumLocalization = ModificationTypeEnumLocalization;
  dataModifiedEnumLocalization = DataModifiedEnumLocalization;

  constructor (private personHistoryService: PersonHistoryService, private route: ActivatedRoute) {}

  ngOnInit (): void{
    const id = parseInt(this.route.snapshot.paramMap.get('id')!)
    this.personHistoryService.getPersonHistoryById(id).subscribe((personHistories: PersonHistoryDto[]) => {
      this.personHistories = personHistories;
    
    })
  } 

}
