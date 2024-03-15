import { GenderEnum } from "../../enums/gender.enum";
import { SchoolDto } from "../../school/all-schools/dtos/school-dto";

export class PersonDetailsDto {
  id: number;
  firstName: string;
  middleName: string;
  lastName: string;
  uic: string;
  birthDate: Date;
  gender: GenderEnum;
  schoolId: number;
  school: SchoolDto;
  birthPlaceId: number;
}
