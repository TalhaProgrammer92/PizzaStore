using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Entities;
using PizzaStore.Enums;
using PizzaStore.Repositories.IRepositories;
using System.Drawing;

namespace PizzaStore.Repositories
{
    public class PizzaRepository : GenericRepository<Pizza>, IPizzaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PizzaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // Get pizza by size
        public async Task<IEnumerable<Pizza>> GetBySize(PizzaSize size)
        {
            return await _dbSet.Where(p => p.Size == size).ToListAsync();
        }

        // Get pizza by price range
        public async Task<IEnumerable<Pizza>> GetByPrice(decimal price)
        {
            return await _dbSet.Where(p => p.Price == price).ToListAsync();
        }

        public async Task<IEnumerable<Pizza>> GetByPriceRange(decimal priceStart, decimal priceEnd)
        {
            return await _dbSet.Where(p => p.Price >= priceStart && p.Price <= priceEnd).ToListAsync();
        }
    }
}
