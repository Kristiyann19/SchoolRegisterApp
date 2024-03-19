import { SchoolTypeEnum } from "../../enums/school-type.enum";
import { SettlementDto } from "../../settlement/dtos/settlement-dto";

export class AddSchoolDto{
  name: string;
  nameAlt: string;
  type: SchoolTypeEnum;
  settlementId: number;
  isActive: boolean
}