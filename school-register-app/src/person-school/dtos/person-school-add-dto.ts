import { PositionEnum } from "../../enums/position.enum";

export class PersonSchoolAddDto {
  position: PositionEnum;
  personId: number;
  schoolId: number;
  startDate: Date;
  endDate: Date;
}
