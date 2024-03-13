import { PositionEnum } from "../../enums/position.enum";

export class PersonSchoolDto {
  id: number;
  position: PositionEnum;
  personId: number;
  schoolId: number;
  startDate: Date;
  endDate: Date;
}


// public int Id { get; set; }

// public Position Position { get; set; }

// public int PersonId { get; set; }

// public int SchoolId { get; set; }

// public DateTime StartDate { get; set; }

// public DateTime EndDate { get; set; }