using Microsoft.EntityFrameworkCore;
using PizzaStore.ApplicationCore.DTOs.PizzaDTO;
using PizzaStore.ApplicationCore.Interfaces.Services;
using PizzaStore.Domain.Entities.Pizza;
using PizzaStore.Domain.Entities.PizzaVariety;
using PizzaStore.Infrastructure.Data;
using PizzaStore.Infrastructure.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PizzaStore.Presentation.ViewModels.ManagePizzas
{
    public class ManagePizzasViewModel : BaseViewModel
    {
        private readonly PizzaStoreDbContext _context;
        private readonly IPizzaService _pizzaService;
        private readonly IPizzaVarietyService _pizzaVarietyService;

        public ObservableCollection<PizzaVariety> PizzaVarieties { get; set; }
        public ObservableCollection<PizzaDto> PizzaDtos { get; set; }
        
        // Pizza Form - Properties
        private decimal _pizzaPrice;
        public decimal PizzaPrice
        {
            get => _pizzaPrice;
            set => SetProperty(ref _pizzaPrice, value);
        }

        private string? _pizzaDescription;
        public string? PizzaDescription
        {
            get => _pizzaDescription;
            set => SetProperty(ref _pizzaDescription, value);
        }

        private string? _selectedSize;
        public string? SelectedSize
        {
            get => _selectedSize;
            set => SetProperty(ref _selectedSize, value);
        }

        private string? _imageUrl;
        public string? ImageUrl
        {
            get => _imageUrl;
            set => SetProperty(ref _imageUrl, value);
        }

        private PizzaVariety? _selectedVariety;
        public PizzaVariety? SelectedVariety
        {
            get => _selectedVariety;
            set => SetProperty(ref _selectedVariety, value);
        }

        // Commands
        public ICommand AddPizzaCommand { get; }

        // Constructor
        public ManagePizzasViewModel(PizzaStoreDbContext context, IPizzaVarietyService varietyService, IPizzaService pizzaService)
        {
            _pizzaVarietyService = varietyService;
            _pizzaService = pizzaService;
            _context = context;

            AddPizzaCommand = new RelayCommand(async _ => await AddPizzaAsync(), _ => true);

            PizzaVarieties = new ObservableCollection<PizzaVariety>();
            PizzaDtos = new ObservableCollection<PizzaDto>();

            LoadVarietiesAsync().ConfigureAwait(false);
            LoadAllPizzasAsync().ConfigureAwait(false);
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

        private bool CanAddPizza()
        {
            return SelectedVariety != null
                && SelectedSize != null
                && PizzaPrice > 0;
        }

        private async Task AddPizzaAsync()
        {
            // Adding pizza
            var dto = new PizzaDto
            {
                Id = Guid.NewGuid(),
                Description = PizzaDescription,
                Size = SelectedSize!,
                PizzaVarietyId = SelectedVariety!.Id,
                Price = PizzaPrice,
                ImageUrl = ImageUrl!,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };

            await _pizzaService.AddAsync(dto);

            // Re-Loading DataGrid
            await LoadAllPizzasAsync();

            // Clear form
            ClearForm();
        }

        private async Task LoadAllPizzasAsync()
        {
            var list = await _pizzaService.GetAllAsync();
            PizzaDtos.Clear();
            foreach (var p in list) PizzaDtos.Add(p);
        }

        private void ClearForm()
        {
            SelectedVariety = null;
            SelectedSize = null;
            PizzaPrice = 0;
            PizzaDescription = string.Empty;
            ImageUrl = string.Empty;
        }
    }
}
