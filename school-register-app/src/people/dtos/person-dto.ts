import { SettlementDto } from "../../settlement/dtos/settlement-dto";

export class PersonDto {
  id: number;
  firstName: string;
  lastName: string;
  uic: string;
  birthDate: Date;
  birthPlace: SettlementDto;
}
