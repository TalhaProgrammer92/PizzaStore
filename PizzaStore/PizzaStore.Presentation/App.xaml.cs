using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.ApplicationCore.Interfaces.Services;
using PizzaStore.Infrastructure;
using PizzaStore.Infrastructure.Data;
using PizzaStore.Infrastructure.JWT;
using PizzaStore.Infrastructure.Mapping;
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

        //public App()
        //{
        //    // Loading theme manually
        //    var paletteHelper = new PaletteHelper();
        //    var theme = paletteHelper.GetTheme();
        //    theme.SetPrimaryColor(System.Windows.Media.Colors.OrangeRed);
        //    theme.SetSecondaryColor(System.Windows.Media.Colors.LimeGreen);
        //    paletteHelper.SetTheme(theme);
        //}

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Loading theme manually
            //var paletteHelper = new PaletteHelper();
            //var theme = paletteHelper.GetTheme();

            //theme.SetPrimaryColor(System.Windows.Media.Colors.OrangeRed);
            //theme.SetSecondaryColor(System.Windows.Media.Colors.Red);

            //paletteHelper.SetTheme(theme);

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
                    services.AddScoped(typeof(IGeneralRepository<>), typeof(GeneralRepository<>));
                    services.AddScoped<IUserRepository, UserRepository>();

                    services.AddScoped<IAuthService, AuthService>();
                    services.AddScoped<ITokenService, JwtTokenService>();
                    services.AddScoped<IPizzaService, PizzaService>();
                    services.AddScoped<IPizzaVarietyService, PizzaVarietyService>();
                    services.AddScoped<IUserService, UserService>();
                    services.AddScoped<IOrderService, OrderService>();

                    // Automapper
                    services.AddAutoMapper(typeof(MappingProfile));

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