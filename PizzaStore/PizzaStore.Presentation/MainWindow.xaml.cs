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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //var context = new PizzaStoreDbContext();
            //var viewModel = new ManagePizzasViewModel(context);
            //MainFrame.Content = new ManagePizzasView(viewModel);
            var view = App.Current.Services.GetRequiredService<ManagePizzasView>();
            MainFrame.Content = view;
        }
    }
}