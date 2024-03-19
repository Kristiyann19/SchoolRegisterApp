import { RoleEnum } from "../../enums/role.enum";
import { SchoolDto } from "../../school/dtos/school-dto";

export class UserDto {
  id: number;
  username: string;
  phone: string;
  school: SchoolDto;
  role: RoleEnum;
}
