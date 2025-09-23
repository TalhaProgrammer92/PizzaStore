using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Repositories.IRepositories;
using System.Linq.Expressions;

namespace PizzaStore.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                var createdEntity = (await _dbSet.AddAsync(entity)).Entity; // Capture the created entity
                await _context.SaveChangesAsync(); // Save changes to the database
                return createdEntity; // Return the created entity

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChangesAsync();
        }

        public void Remove(TEntity entity)
        {

            _dbSet.Remove(entity);
            _context.SaveChangesAsync();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dbSet;
        }


        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.CountAsync(predicate);
        }

        Task IGenericRepository<TEntity>.AddAsync(TEntity entity)
        {
            return AddAsync(entity);
        }

        public IQueryable<TEntity> GetByQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
