import { PositionEnum } from "../../enums/position.enum";

export class PersonSchoolDto {
  id: number;
  position: PositionEnum;
  personId: number;
  schoolId: number;
  startDate: Date;
  endDate: Date;
}
