using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PizzaStore.Data;
using PizzaStore.Mapping;
using PizzaStore.Models;
using PizzaStore.Repositories;
using PizzaStore.Repositories.IRepositories;
using PizzaStore.Services;
using PizzaStore.Services.IServices;
using System.Data;
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

        public static IServiceCollection AddServiceDI(this IServiceCollection services)
        {
            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddDataDI(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DesktopConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("The connection string is missing or empty. Please check your configuration.");
            }

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.CommandTimeout(80);
                    sqlOptions.EnableRetryOnFailure();
                }));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }

        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddCoreDI(configuration);
            //services.AddServiceDI();
            //return services;

            // Validate ConnectionString
            var connectionString = configuration.GetConnectionString("DesktopConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("The DesktopConnection string is missing or empty. Please check your configuration.");
            }
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DesktopConnection"),
                sqlOptions =>
                {
                    sqlOptions.CommandTimeout(80);
                    sqlOptions.EnableRetryOnFailure();
                }
            ));

            //// Configure Hangfire with SQL Server
            //services.AddHangfire(config =>
            //{
            //    config.UseSqlServerStorage(connectionString);
            //});

            //// Add Hangfire Server
            //services.AddHangfireServer();

            // Rate Limiting
            services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter("FixedWindowPolicy", limiterOptions =>
                {
                    limiterOptions.Window = TimeSpan.FromMinutes(1);
                    limiterOptions.PermitLimit = 100;
                    limiterOptions.QueueLimit = 10;
                    limiterOptions.AutoReplenishment = true;
                });
            });

            // Identity Configuration
            //services.AddIdentity<User, Role>(options =>
            //{
            //    options.Password.RequireDigit = false;
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.User.RequireUniqueEmail = true;
            //})
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders();

            // Swagger Configuration
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "PizazStore API", Version = "v1" });

                // Add JWT Authentication to Swagger
                //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "Bearer",
                //    BearerFormat = "JWT",
                //    In = ParameterLocation.Header,
                //    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'"
                //});

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }
    }
}
