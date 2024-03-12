import { GenderEnum } from "../../enums/gender.enum";

export class PersonDetailsDto{ 
  id: number;
  firstName: string;
  middleName: string;
  lastName: string;
  uic: string;
  birthDate: Date;
  gender: GenderEnum;
  birthPlace: string;
}