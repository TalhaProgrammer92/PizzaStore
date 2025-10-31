using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Entities.Feedback;
using PizzaStore.Domain.Entities.Order;
using PizzaStore.Domain.Entities.OrderItem;
using PizzaStore.Domain.Entities.Pizza;
using PizzaStore.Domain.Entities.PizzaVariety;
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
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PizzaVariety> PizzaVarieties { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - Configuration
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username).IsUnique();

            // Pizza - Configuration
            modelBuilder.Entity<Pizza>()
                .HasOne(p => p.PizzaVariety)
                .WithMany(pv => pv.Pizzas)
                .HasForeignKey(p => p.PizzaVarietyId);

            // Order - Configuration
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            // OrderItem - Configuration
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);
            
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Pizza)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.PizzaId);

            // Feedback - Configuration
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.User)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.UserId);
        }
    }
}
