using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Presentation.Views.ManagePizzas;
using System.Windows;

namespace PizzaStore.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Open the Manage Pizzas view
        private void ManagePizzas_Checked(object sender, RoutedEventArgs e)
        {
            var view = App.Services.GetRequiredService<ManagePizzasView>();
            MainFrame.Content = view;
        }

        // Open the Manage Pizza Varieties view
        private void ManagePizzaVarieties_Checked(object sender, RoutedEventArgs e)
        {
            var view = App.Services.GetRequiredService<ManagePizzasVarietyView>();
            MainFrame.Content = view;
        }
    }
}