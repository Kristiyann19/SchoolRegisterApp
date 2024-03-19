import { PositionEnum } from "../../enums/position.enum";
import { SchoolDto } from "../../school/dtos/school-dto";

export class ReportDto {
  schoolId: number;

  school: SchoolDto
  position: PositionEnum;
  peopleCount: number;
}
