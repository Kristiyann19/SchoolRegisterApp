using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Dtos.PersonSchoolDtos
{
    public class PersonSchoolAddDto
    {
        public PositionEnum Position { get; set; }

        public int PersonId { get; set; }

        public int SchoolId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
