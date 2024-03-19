using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Entities
{
    public class PersonSchool
    {
        public int Id { get; set; }

        public PositionEnum Position { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int SchoolId { get; set; }

        public School School { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }

    public class PersonSchoolConfiguration : IEntityTypeConfiguration<PersonSchool>
    {
        public void Configure(EntityTypeBuilder<PersonSchool> builder)
        {

            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Position)
                .IsRequired();

            builder
                .Property(b => b.StartDate)
                .IsRequired();
        }
    }

}
