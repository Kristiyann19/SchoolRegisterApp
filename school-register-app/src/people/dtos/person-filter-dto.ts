export class PersonFilterDto {
  firstName: string;
  lastName: string;
  uic: string;
  gender: string;
  birthPlace: string;
  page: number;
  pageSize: number = 3;
}
