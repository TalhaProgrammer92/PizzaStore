using Microsoft.EntityFrameworkCore;
using PizzaStore.Entities;

namespace PizzaStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /* <----- All DbSets -----> */
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }

        // OnModelCreating -- Method (Override)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Pizza Entity Configuration
            modelBuilder.Entity<Pizza>()
                .HasKey(p => p.Id);

            // User Entity Configuration
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
        }
    }
}
