using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.ApplicationCore.Interfaces.Services;
using PizzaStore.ApplicationCore.Services.AuthService;
using PizzaStore.ApplicationCore.Services.JwtTokenService;
using PizzaStore.Infrastructure.Data;
using PizzaStore.Infrastructure.Repositories;
using PizzaStore.Presentation.ViewModels;
using System.Configuration;
using System.Data;
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
                    services.AddSingleton<MainWindow>();
                    //services.AddTransient<MainWindowViewModel>();
                    services.AddTransient<LoginViewModel>();

                    // other services...
                })
                .Build();

            await _host.StartAsync();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
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