using PizzaStore.DTOs;
using PizzaStore.Enums;

namespace PizzaStore.Services.IServices
{
    public interface IPizzaService
    {
        Task<IEnumerable<PizzaDto>> GetAllPizzasAsync();
        Task<PizzaDto?> GetPizzaByIdAsync(Guid id);
        Task AddPizzaAsync(PizzaDto pizzaDto);
        Task UpdatePizzaAsync(PizzaDto pizzaDto);
        Task DeletePizzaAsync(Guid id);
    }
}
