using Microsoft.EntityFrameworkCore;
using PizzaHutAPI.Models;

namespace PizzaHutAPI.Context
{
    public class DBPizzaHutContext : DbContext
    {
        public DBPizzaHutContext(DbContextOptions<DBPizzaHutContext> options) : base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Pizza>().HasData(
                new Models.Pizza
                {
                    Id = 1,
                    Name = "Margherita",
                    Description = "Cheese and Tomato",
                    Price = 300,
                    QtyInHand = 0,
                    status = Models.PizzaStatus.UnAvailable
                },
                new Models.Pizza
                {
                    Id = 2,
                    Name = "Pepperoni",
                    Description = "Pepperoni and Cheese",
                    Price = 500,
                    QtyInHand = 0,
                    status = Models.PizzaStatus.UnAvailable
                });
            modelBuilder.Entity<UserInfo>()
                .HasKey(ui => ui.Id);
            modelBuilder.Entity<User>()
                .HasOne(ui => ui.UserInfo)
                .WithOne(u => u.User)
                .HasForeignKey<UserInfo>(ui => ui.Id);

        }


    }
}
