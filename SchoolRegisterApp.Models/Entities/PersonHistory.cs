using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Entities
{
    public class PersonHistory
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int UserId { get; set; }

        public Users User { get; set; }

        public DateTime ActionDate { get; set; }

        public DataModified DataModified { get; set; }

        public ModificationType ModificationType { get; set; }
    }

    public class PersonHistoryConfiguration : IEntityTypeConfiguration<PersonHistory>
    {
        public void Configure(EntityTypeBuilder<PersonHistory> builder)
        {
           
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.ActionDate)
                .IsRequired();

            builder
                .Property(x => x.DataModified)
                .IsRequired();

            builder
                .Property(x => x.ModificationType);
        }
    }
}
