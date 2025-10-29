using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.ApplicationCore.Interfaces.Services;
using PizzaStore.Infrastructure;
using PizzaStore.Infrastructure.Data;
using PizzaStore.Infrastructure.JWT;
using PizzaStore.Infrastructure.Repositories;
using PizzaStore.Infrastructure.Services;
using PizzaStore.Presentation.ViewModels;
using PizzaStore.Presentation.Views;
using System.Windows;

namespace PizzaStore.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost? _host;

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    var configuration = context.Configuration;
                    services.AddDbContext<PizzaStoreDbContext>(opts =>
                        opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

                    // Application & Infrastructure registrations
                    services.AddScoped<IUserRepository, UserRepository>();
                    services.AddScoped<IAuthService, AuthService>();
                    services.AddScoped<ITokenService, JwtTokenService>();

                    // ViewModels & Views
                    services.AddTransient<LoginViewModel>();
                    services.AddTransient<MainWindowViewModel>();
                    services.AddSingleton<MainWindow>();

                    services.AddTransient<LoginView>();
                    services.AddTransient<MainWindow>();
                })
                .Build();

            await _host.StartAsync();

            await DbSeeder.SeedAsync(_host.Services);

            var window = _host.Services.GetRequiredService<LoginView>();
            window.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            if (_host != null)
            {
                await _host.StopAsync();
                _host.Dispose();
            }
            base.OnExit(e);
        }
    }
}