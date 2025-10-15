using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Entities;
using PizzaStore.Domain.Entities.Order;
using PizzaStore.Domain.Entities.Pizza;
using PizzaStore.Domain.Entities.User;

namespace PizzaStore.Infrastructure.Data
{
    public class PizzaStoreDbContext : DbContext
    {
        public PizzaStoreDbContext(DbContextOptions<PizzaStoreDbContext> options) : base(options) { }

        /* <---- DbSet Properties ----> */
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - Configuration
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username).IsUnique();
        }
    }
}
