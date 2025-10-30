using Microsoft.EntityFrameworkCore;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        private readonly PizzaStoreDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GeneralRepository(PizzaStoreDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IQueryable<T>?> GetAllAsync()
        {
            // I'm returning IQueryable to allow for further querying/filtering by the caller/service
            return _dbSet.AsQueryable();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T obj)
        {
            await _dbSet.AddAsync(obj);
        }

        public async Task<T> UpdateAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new Exception($"Entity with ID {id} not found.");

            _dbSet.Update(entity);
            return entity;
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new Exception($"Entity with ID {id} not found.");

            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
