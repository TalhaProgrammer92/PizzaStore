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

        // OnModelCreating -- Method (Override)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pizza>()
                .HasKey(p => p.Id);
        }
    }
}
