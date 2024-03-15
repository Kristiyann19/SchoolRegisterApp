import { PositionEnum } from "../../enums/position.enum";

export class PersonSchoolUpdateDto {
  id: number;
  position: PositionEnum;
  personId: number;
  schoolId: number;
  startDate: Date;
  endDate: Date;
}
