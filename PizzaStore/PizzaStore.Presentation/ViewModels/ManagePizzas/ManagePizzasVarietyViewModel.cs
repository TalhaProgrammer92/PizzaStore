using PizzaStore.ApplicationCore.DTOs.PizzaVarietyDTO;
using PizzaStore.Infrastructure.Data;
using PizzaStore.Infrastructure.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PizzaStore.Presentation.ViewModels.ManagePizzas
{
    public class ManagePizzasVarietyViewModel : BaseViewModel
    {
        private readonly PizzaStoreDbContext _context;
        private readonly IPizzaVarietyService _service;

        public ObservableCollection<PizzaVarietyDto> PizzaVarietyDtos { get; set; }

        // Form Properties
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        // Command
        public ICommand AddPizzaVarietyCommand { get; }

        // Constructor
        public ManagePizzasVarietyViewModel(PizzaStoreDbContext context, IPizzaVarietyService service)
        {
            _context = context;
            _service = service;

            AddPizzaVarietyCommand = new RelayCommand(async _ => await AddPizzaVarietyAsync());

            PizzaVarietyDtos = new ObservableCollection<PizzaVarietyDto>();

            // Load data grid on first load
            LoadAllPizzaVarietiesAsync().ConfigureAwait(false);
        }

        // Check if new variety is addable
        private bool CanAddPizzaVariety()
        {
            return !(string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name));
        }

        // Add new pizza variety
        private async Task AddPizzaVarietyAsync()
        {
            // Check
            if (!CanAddPizzaVariety())
            {
                MessageBox.Show("Please enter a name for the pizza variety before adding.", "Validation Error");
                return;
            }

            // Create DTO
            var dto = new PizzaVarietyDto
            {
                Id = Guid.NewGuid(),
                //Name = Name.Trim(),
                Name = Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };

            // Add to database
            await _service.AddAsync(dto);

            // Load data grid
            await LoadAllPizzaVarietiesAsync();

            // Clear form
            ClearForm();
        }

        // Load all pizza varieties
        private async Task LoadAllPizzaVarietiesAsync()
        {
            var varieties = await _service.GetAllAsync();
            PizzaVarietyDtos.Clear();
            foreach (var variety in varieties)
            {
                PizzaVarietyDtos.Add(variety);
            }
        }

        // Clear form
        public void ClearForm()
        {
            Name = string.Empty;
        }
    }
}
