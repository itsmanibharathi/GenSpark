using Microsoft.EntityFrameworkCore;
using RequestTracerAPI.Models;

namespace RequestTracerAPI.Context
{
    public class DBRequestTrackerContext : DbContext
    {
        public DBRequestTrackerContext(DbContextOptions<DBRequestTrackerContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 101,
                    Name = "Mani",
                    Role = EmployeeRole.Admin,
                    DateOfBirth = new DateTime(2001, 1, 1),
                    PhoneNumber = "1234567890"
                },
                new Employee
                {
                    Id = 102,
                    Name = "Kiko",
                    Role = EmployeeRole.Employee,
                    DateOfBirth = new DateTime(2002, 1, 1),
                    PhoneNumber = "9876543210"
                }
            );
        }
    }
}
