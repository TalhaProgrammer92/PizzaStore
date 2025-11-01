using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Entities.Cart;
using PizzaStore.Domain.Entities.CartItem;
using PizzaStore.Domain.Entities.Feedback;
using PizzaStore.Domain.Entities.Order;
using PizzaStore.Domain.Entities.OrderItem;
using PizzaStore.Domain.Entities.Payment;
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
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaVariety> PizzaVarieties { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User - Configuration
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username).IsUnique();

            // Feedback - Configuration
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.User)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.UserId);

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

            // Cart - Configuration
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId);

            // CartItem - Configuration
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Pizza)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.PizzaId);

            // Payment - Configuration
            modelBuilder.Entity<Payment>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.Payments)
                .HasForeignKey(oi => oi.OrderId);
        }
    }
}
