using SchoolRegisterApp.Models.Entities;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Dtos.PersonDtos
{
    public class PersonDetailsDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Uic { get; set; }

        public DateTime BirthDate { get; set; }

        public GenderEnum Gender { get; set; }

        public int BirthPlaceId { get; set; }
    }
}


