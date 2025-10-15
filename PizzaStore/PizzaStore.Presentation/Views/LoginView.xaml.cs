using PizzaStore.Presentation.ViewModels;
using System.Windows;

namespace PizzaStore.Presentation.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView(LoginViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;

            // Just for debugging
            /*
            Loaded += (s, e) =>
            {
                MessageBox.Show($"DataContext is {DataContext?.GetType().Name}");
            };
            */
        }
    }
}
