using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Dtos
{
    public class ReportDto
    {
        public int SchoolId { get; set; }
        public School School { get; set; }

        public PositionEnum Position { get; set; }

        public int PeopleCount { get; set; }
    }
}
