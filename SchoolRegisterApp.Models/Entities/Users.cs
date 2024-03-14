using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models.Enums;

namespace SchoolRegisterApp.Models.Entities
{
    public class Users
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Phone { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public int? SchoolId { get; set; }

        public School School { get; set; }

        public RoleEnum Role { get; set; }

        public bool IsActive { get; set; }
    }

    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder
                .Property(b => b.Username)
                .IsRequired();

            builder
                .HasIndex(b => b.Username)
                .IsUnique();

            builder
                .Property(b => b.Phone)
                .IsRequired();

            builder
                .Property(b => b.PasswordHash)
                .IsRequired();

            builder
                .Property(b => b.PasswordSalt)
                .IsRequired();

            builder
                .Property(b => b.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
