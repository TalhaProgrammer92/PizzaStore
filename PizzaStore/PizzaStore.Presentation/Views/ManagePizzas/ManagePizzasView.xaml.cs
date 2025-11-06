using PizzaStore.Presentation.ViewModels.ManagePizzas;
using System.Windows.Controls;

namespace PizzaStore.Presentation.Views.ManagePizzas
{
    /// <summary>
    /// Interaction logic for ManagePizzasView.xaml
    /// </summary>
    public partial class ManagePizzasView : UserControl
    {
        public ManagePizzasView(ManagePizzasViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
