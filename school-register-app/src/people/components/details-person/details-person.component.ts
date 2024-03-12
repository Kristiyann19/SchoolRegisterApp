import { Component } from "@angular/core";
import { PersonService } from "../../services/person.service";
import { PersonDetailsDto } from "../../dtos/person-details-dto";
import { GenderEnumLocalization } from "../../../enums/gender.enum";
import { ActivatedRoute, Router } from "@angular/router";
import { SettlementDto } from "../../../settlement/dtos/settlement-dto";
import { catchError, throwError } from "rxjs";
import { SettlementService } from "../../../settlement/services/settlement.service";

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
  constructor(private route: ActivatedRoute, private personService: PersonService, private router: Router, private settlementService: SettlementService) {}



  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.personId = +params['id'];
      this.fetchCarDetails(); 
      this.getSettlements();
    });
  }



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

  fetchCarDetails(): void {
    this.personService.getById(this.personId).subscribe((person) => {
      this.person = { ...person }; 
    });
  }


  // ngOnInit (): void{
  //   debugger;
  //   const id = parseInt(this.route.snapshot.paramMap.get('id')!)
  //   this.personService.getById(id).subscribe((person: PersonDetailsDto) => {
  //     this.person = person;
  //   })
  // }  

  updatePerson() : void {
    this.personService.updatePerson(this.personId, this.person).subscribe(() => {
      this.router.navigate(['/all-people'])
    })
  }


}
