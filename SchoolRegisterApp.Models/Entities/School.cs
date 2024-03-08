using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Entities
{
    public class School
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameAlt { get; set; }

        public SchoolTypeEnum Type { get; set; }

        public int SettlementId { get; set; }

        public Settlement Settlement { get; set; }

        public bool IsActive { get; set; }
    }

    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .Property(x => x.NameAlt)
                .IsRequired();

            builder
                .Property(x => x.Type)
                .IsRequired();

            builder
                .Property(x => x.IsActive)
                .HasDefaultValue(true);
        }
    }
}
