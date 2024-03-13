import { DataModifiedEnum } from "../../enums/data-modified.enum";
import { ModificationTypeEnum } from "../../enums/modification-type.enum";

export class PersonHistoryDto { 
  id: number;
  personId: number;
  userId: number;
  actionDate: Date;
  dataModified: DataModifiedEnum;

  modificationType: ModificationTypeEnum;
}
