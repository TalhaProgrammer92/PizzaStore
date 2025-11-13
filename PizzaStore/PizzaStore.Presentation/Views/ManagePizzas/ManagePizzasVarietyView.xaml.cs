using PizzaStore.Presentation.ViewModels.ManagePizzas;
using System.Windows.Controls;

namespace PizzaStore.Presentation.Views.ManagePizzas
{
    /// <summary>
    /// Interaction logic for ManagePizzasVarietyView.xaml
    /// </summary>
    public partial class ManagePizzasVarietyView : UserControl
    {
        public ManagePizzasVarietyView(ManagePizzasVarietyViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
