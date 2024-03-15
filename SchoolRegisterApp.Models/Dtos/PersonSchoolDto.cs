using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Dtos
{
    public class PersonSchoolDto
    {
        public int Id { get; set; }

        public PositionEnum Position { get; set; }

        public int PersonId { get; set; }

        public int SchoolId { get; set; }

        public string SchoolName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
