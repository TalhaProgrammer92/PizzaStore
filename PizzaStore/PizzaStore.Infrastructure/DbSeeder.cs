using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Domain.Entities.Order;
using PizzaStore.Domain.Entities.Pizza;
using PizzaStore.Domain.Entities.User;
using PizzaStore.Domain.Enums;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<PizzaStoreDbContext>();

            // Apply migrations automatically if not applied
            await context.Database.MigrateAsync();

            // --- Users ---
            if (!context.Users.Any())
            {
                // Because Admin is already created inside database
                // username: admin, password: 12345

                // Uncomment the following lines of code only if you're running this application fresh and no admin user data exists in your database
                //var admin = new User
                //{
                //    Username = "admin",
                //    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                //    Role = Role.Admin
                //};

                var customer = new User
                {
                    Username = "customer",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("customer123"),
                    Role = Role.Customer
                };

                await context.Users.AddRangeAsync(customer);
                await context.SaveChangesAsync();
            }

            // --- Pizzas ---
            //if (!context.Pizzas.Any())
            //{
            //    await context.Pizzas.AddRangeAsync(
            //        new Pizza { Name = "Margherita", Description = "Classic cheese & tomato", Price = 7.99M },
            //        new Pizza { Name = "Pepperoni", Description = "Spicy pepperoni & mozzarella", Price = 9.49M },
            //        new Pizza { Name = "BBQ Chicken", Description = "Grilled chicken, BBQ sauce & cheese", Price = 10.99M },
            //        new Pizza { Name = "Veggie Delight", Description = "Loaded with mushrooms, peppers & olives", Price = 8.99M }
            //    );
            //    await context.SaveChangesAsync();
            //}

            // --- Toppings ---
            //if (!context.Toppings.Any())
            //{
            //    await context.Toppings.AddRangeAsync(
            //        new Topping { Name = "Extra Cheese", Price = 1.50M },
            //        new Topping { Name = "Mushrooms", Price = 1.00M },
            //        new Topping { Name = "Olives", Price = 0.80M },
            //        new Topping { Name = "Jalapeños", Price = 1.00M },
            //        new Topping { Name = "Onions", Price = 0.70M }
            //    );
            //    await context.SaveChangesAsync();
            //}

            // --- Sample Order (Optional) ---
            //if (!context.Orders.Any())
            //{
            //    var customer = await context.Users.FirstOrDefaultAsync(u => u.Username == "customer");
            //    var margherita = await context.Pizzas.FirstOrDefaultAsync(p => p.Name == "Margherita");

            //    if (customer != null && margherita != null)
            //    {
            //        var order = new Order
            //        {
            //            UserId = customer.Id,
            //            TotalPrice = margherita.Price,
            //            OrderDate = DateTime.UtcNow,
            //            Status = "Completed"
            //        };

            //        await context.Orders.AddAsync(order);
            //        await context.SaveChangesAsync();
            //    }
            //}
        }
    }
}
