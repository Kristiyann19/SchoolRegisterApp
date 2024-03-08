using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Uic { get; set; }

        public DateTime BirthDate { get; set; }

        public GenderEnum Gender { get; set; }

        public int BirthPlaceId { get; set; }

        public Settlement BirthPlace { get; set; }
    }

    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

        }
    }
}

