using Microsoft.EntityFrameworkCore;

namespace PizzaHutAPI.Context
{
    public class DBPizzaHutContext : DbContext
    {
        public DBPizzaHutContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Pizza> Pizzas { get; set; }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.UserInfo> UserInfos { get; set; }

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

            modelBuilder.Entity<Models.User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Models.User>()
                .HasOne(u => u.UserInfo)
                .WithOne(ui => ui.User)
                .HasForeignKey<Models.UserInfo>(ui => ui.Id);
        }
    }
}
