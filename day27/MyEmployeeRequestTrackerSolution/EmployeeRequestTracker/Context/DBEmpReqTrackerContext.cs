using EmployeeRequestTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTracker.Context
{
    public class DBEmpReqTrackerContext : DbContext
    {
        public DBEmpReqTrackerContext(DbContextOptions<DBEmpReqTrackerContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);
            modelBuilder.Entity<User>().HasKey(u => u.EmployeeId);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.user)
                .WithOne(u => u.employee)
                .HasForeignKey<User>(u => u.EmployeeId);
            modelBuilder.Entity<Request>().HasKey(r => r.RequestId);
            modelBuilder.Entity<Request>()
                .HasOne(r => r.RaisedByEmployee)
                .WithMany(e => e.RaiseRequests)
                .HasForeignKey(r => r.RaisedBy);
            modelBuilder.Entity<Request>()
                .HasOne(r => r.SolvedByEmployee)
                .WithMany(e => e.SolveRequests)
                .HasForeignKey(r => r.SolvedBy);
        }


    }
}
