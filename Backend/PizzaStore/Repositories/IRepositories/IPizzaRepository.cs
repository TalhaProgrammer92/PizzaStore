using PizzaStore.Entities;
using PizzaStore.Enums;

namespace PizzaStore.Repositories.IRepositories
{
    public interface IPizzaRepository : IGenericRepository<Pizza>
    {
        // Get pizza by size
        Task<IEnumerable<Pizza>> GetBySize(PizzaSize size);

        // Get pizza by price range
        Task<IEnumerable<Pizza>> GetByPrice(decimal price);
        Task<IEnumerable<Pizza>> GetByPriceRange(decimal priceStart, decimal priceEnd);
    }
}
