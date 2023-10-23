using Microsoft.EntityFrameworkCore;
using PizzaOrderApp.Data.Models;

namespace PizzaOrderApp.Data.Database
{
    public class PizzaOrderAppDbContext : DbContext
    {
        public DbSet<PizzaOrder> PizzaOrders { get; set; }
        public DbSet<PizzaSize> PizzaSize { get; set; }
        public DbSet<Topping> Toppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("PizzaAppDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaOrderTopping>().HasKey(c => new
            {
                c.PizzaOrderId,
                c.ToppingId
            });
        }
    }
}

