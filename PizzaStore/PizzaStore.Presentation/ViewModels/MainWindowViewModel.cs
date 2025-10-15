using PizzaStore.Presentation;
using System.Windows.Input;

namespace PizzaStore.Presentation.ViewModels
{
    // Dashboard or main window view model after login
    public class MainWindowViewModel : BaseViewModel
    {
        private string _welcomeMessage;
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set => SetProperty(ref _welcomeMessage, value);
        }

        public ICommand LogoutCommand { get; }

        public MainWindowViewModel()
        {
            WelcomeMessage = "Welcome to PizzaStore!";
            LogoutCommand = new RelayCommand(_ => Logout());
        }

        private void Logout()
        {
            // In real app, navigate to LoginView or clear session
            WelcomeMessage = "You have logged out successfully.";
        }
    }
}
