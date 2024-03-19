import { SchoolIdAndNameDto } from "../../school/dtos/school-id-and-name-dto";
import { SettlementDto } from "../../settlement/dtos/settlement-dto";

export class PersonDto {
  id: number;
  firstName: string;
  lastName: string;
  uic: string;
  birthDate: Date;
  schoolId : number;
 
  birthPlace: SettlementDto;
}
