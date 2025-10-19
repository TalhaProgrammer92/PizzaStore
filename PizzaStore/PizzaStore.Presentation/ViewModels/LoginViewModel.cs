using PizzaStore.ApplicationCore.Interfaces.Services;
using PizzaStore.Domain.ValueObjects;
using System.Windows;

namespace PizzaStore.Presentation.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private string _username;
        private string _password;
        private string _statusMessage;

        public LoginViewModel(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
            LoginCommand = new AsyncRelayCommand(ExecuteLoginAsync, CanLogin);
        }

        public string Username
        {
            get => _username;
            set 
            {
                SetProperty(ref _username, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public AsyncRelayCommand LoginCommand { get; }

        // If you have an IAuthService registered via DI, inject it here.
        // For now I'll keep it simple and show a fake login flow.
        public LoginViewModel(ITokenService tokenService)
        {
            _tokenService = tokenService;
            LoginCommand = new AsyncRelayCommand(ExecuteLoginAsync, CanLogin);
        }

        private bool CanLogin() => true;
            //!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);

        private void OpenMainWindow()
        {
            // Use the registered MainWindow via DI
            var mainWindow = new MainWindow();
            mainWindow.Show();

            // Close the login window
            Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.DataContext == this)?
                .Close();
        }

        private async Task ExecuteLoginAsync()
        {
            try
            {
                StatusMessage = string.Empty;

                var user = await _authService.AuthenticateAsync(Username, Password);

                if (user != null)
                {
                    var token = _tokenService.GenerateToken(user.Username);
                    AppSession.JwtToken = token;

                    StatusMessage = "Login successful!";
                    OpenMainWindow();
                }
                else
                {
                    StatusMessage = "Invalid username or password!";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

    }
}
