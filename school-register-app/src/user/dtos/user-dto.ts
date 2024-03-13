import { SchoolDto } from "../../school/all-schools/dtos/school-dto";

export class UserDto {
  id: number;
  username: string;
  phone: string;
  school: SchoolDto;
}
