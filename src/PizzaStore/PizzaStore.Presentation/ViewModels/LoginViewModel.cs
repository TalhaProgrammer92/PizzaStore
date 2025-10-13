namespace PizzaStore.Presentation.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _statusMessage = string.Empty;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public AsyncRelayCommand LoginCommand { get; }

        // If you have an IAuthService registered via DI, inject it here.
        // For now I'll keep it simple and show a fake login flow.
        public LoginViewModel()
        {
            LoginCommand = new AsyncRelayCommand(ExecuteLoginAsync, CanLogin);
        }

        private bool CanLogin() => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);

        private async Task ExecuteLoginAsync()
        {
            // Simulate async authentication (replace with real auth service)
            await Task.Delay(500);

            if (Username == "admin" && Password == "password")
            {
                StatusMessage = "Login successful";
                // TODO: set token in user session, navigate to main view, etc.
            }
            else
            {
                StatusMessage = "Invalid credentials";
            }
        }
    }
}
