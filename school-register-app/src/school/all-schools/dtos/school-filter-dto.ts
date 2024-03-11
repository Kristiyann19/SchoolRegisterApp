import { SchoolTypeEnum } from "../../../enums/school-type.enum";

export class SchoolFilterDto{
  name: string;
  nameAlt: string;
  type: SchoolTypeEnum;
  settlement: string;
}