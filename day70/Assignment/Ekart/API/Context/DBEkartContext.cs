using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class DBEkartContext : DbContext
    {
        public DBEkartContext(DbContextOptions<DBEkartContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                               new Product
                               {
                                   Id = 1,
                                   Name = "Product 1",
                                   Description = "Description 1",
                                   Price = 100,
                                   imageUrl = "https://via.placeholder.com/150",
                                   CreatedDate = System.DateTime.Now
                               });
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
