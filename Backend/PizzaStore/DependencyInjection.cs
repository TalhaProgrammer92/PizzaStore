using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Mapping;
using System.Reflection;

namespace PizzaStore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<DatabaseConnectionOptions>(configuration.GetSection(DatabaseConnectionOptions.SectionName));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());    // -> For all profiles

            //services.AddAutoMapper(typeof(PizzaProfile).Assembly);    // -> For specific profile

            services.AddFluentValidationAutoValidation();   // Enables automatic validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
