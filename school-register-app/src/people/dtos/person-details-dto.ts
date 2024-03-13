import { GenderEnum } from "../../enums/gender.enum";
import { SettlementDto } from "../../settlement/dtos/settlement-dto";

export class PersonDetailsDto{ 
  id: number;
  firstName: string;
  middleName: string;
  lastName: string;
  uic: string;
  birthDate: Date;
  gender: GenderEnum;
  birthPlaceId: number;
}