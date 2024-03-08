using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Entities
{
    public class PersonSchool
    {
        public int Id { get; set; }

        public Position Position { get; set; }

        public int PersonId { get; set; }

        //public Person Person { get; set; }
        public int SchoolId { get; set; }

        //public School School { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
