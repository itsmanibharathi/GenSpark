using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Contexts
{
    public class DBClinicContext : DbContext
    {
        public DBClinicContext(DbContextOptions<DBClinicContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                               {
                    ID = 1,
                    Name = "Dr. Mani",
                    DateOfJoin = new DateTime(2021, 1, 1),
                    Specialization = "General Physician"
                },
                new Doctor
                {
                    ID = 2,
                    Name = "Dr. Kiko",
                    DateOfJoin = new DateTime(2021, 1, 1),
                    Specialization = "Dentist"
                }
                );
        }
    }
}
