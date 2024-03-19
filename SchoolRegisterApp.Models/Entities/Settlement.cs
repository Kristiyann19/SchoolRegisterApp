using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolRegisterApp.Models.Entities
{
    public class Settlement
    {
        public int Id { get; set; }

        public string Ekatte { get; set; }

        public string Name { get; set; }

        public string NameAlt { get; set; }

        public bool IsActive { get; set; }
    }

    public class SettlementConfiguration : IEntityTypeConfiguration<Settlement>
    {
        public void Configure(EntityTypeBuilder<Settlement> builder)
        {
            builder
                .Property(b => b.Ekatte)
                .IsRequired();

            builder
                .HasIndex(b => b.Ekatte)
                .IsUnique();

            builder.Property(b => b.Name)
                .IsRequired();

            builder
                .Property(b => b.NameAlt)
                .IsRequired();

            builder
                .Property(b => b.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }

}
