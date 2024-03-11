import { SchoolTypeEnum } from "../../../enums/school-type.enum";

export class SchoolDto{
  id: number;
  name: string;
  nameAlt: string;
  type: SchoolTypeEnum;
  settlement: string;
  isActive: boolean
}