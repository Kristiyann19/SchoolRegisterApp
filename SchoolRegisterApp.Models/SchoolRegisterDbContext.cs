using Microsoft.EntityFrameworkCore;
using SchoolRegisterApp.Models.Entities;
using System.Reflection;

namespace SchoolRegisterApp.Models
{
    public class SchoolRegisterDbContext : DbContext
    {
        public SchoolRegisterDbContext(DbContextOptions<SchoolRegisterDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<PersonHistory> PersonHistories { get; set; }

        public DbSet<PersonSchool> PersonSchools { get; set; }

        public DbSet<Settlement> Settlements { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ApplyConfiguration(builder);
        }

        protected void ApplyConfiguration(ModelBuilder builder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Any(gi =>
                    gi.IsGenericType
                    && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                builder.ApplyConfiguration(configurationInstance);
            }
        }

    }
}
