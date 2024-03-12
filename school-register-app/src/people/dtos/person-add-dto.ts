import { GenderEnum } from "../../enums/gender.enum";

export class PersonAddDto {
  firstName: string;
  middleName: string;
  lastName: string;
  uic: string;
  birthDate: Date;
  gender: GenderEnum;
  birthPlaceId: number;
}
