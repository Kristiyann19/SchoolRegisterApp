import { SchoolTypeEnum } from "../../enums/school-type.enum";
import { SettlementDto } from "../../settlement/dtos/settlement-dto";

export class SchoolDto{
  id: number;
  name: string;
  nameAlt: string;
  type: SchoolTypeEnum;
  settlement: SettlementDto;
  isActive: boolean
}