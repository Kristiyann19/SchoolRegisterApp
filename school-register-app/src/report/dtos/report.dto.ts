import { PositionEnum } from "../../enums/position.enum";
import { SchoolDto } from "../../school/all-schools/dtos/school-dto";

export class ReportDto {
  schoolId: number;

  school: SchoolDto
  position: PositionEnum;
  peopleCount: number;
}
