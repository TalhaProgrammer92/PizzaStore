using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Entities.PizzaVariety;
using PizzaStore.Infrastructure.Data;
using System.Collections.ObjectModel;

namespace PizzaStore.Presentation.ViewModels.ManagePizzas
{
    public class ManagePizzasViewModel : BaseViewModel
    {
        private readonly PizzaStoreDbContext _context;

        public ObservableCollection<PizzaVariety> PizzaVarieties { get; set; }
        private PizzaVariety? _selectedVariety;
        public PizzaVariety? SelectedVariety
        {
            get => _selectedVariety;
            set => SetProperty(ref _selectedVariety, value);
            //{
            //    _selectedVariety = value;
            //    OnPropertyChanged();
            //}
        }

        public ManagePizzasViewModel(PizzaStoreDbContext context)
        {
            _context = context;
            //PizzaVarieties = new ObservableCollection<PizzaVariety>(_context.PizzaVarieties);
            PizzaVarieties = new ObservableCollection<PizzaVariety>();
            //LoadVarietiesAsync().ConfigureAwait(false);
            LoadVarietiesAsync();
        }

        private async Task LoadVarietiesAsync()
        {
            var varieties = await _context.PizzaVarieties.ToListAsync();
            PizzaVarieties.Clear();
            foreach (var variety in varieties)
            {
                PizzaVarieties.Add(variety);
            }
        }
    }
}
