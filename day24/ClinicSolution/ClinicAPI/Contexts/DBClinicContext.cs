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
    }
}
