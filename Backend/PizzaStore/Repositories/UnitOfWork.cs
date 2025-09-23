using Microsoft.EntityFrameworkCore.Storage;
using PizzaStore.Data;
using PizzaStore.Repositories.IRepositories;

namespace PizzaStore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed = false;
        private IDbContextTransaction? _transaction;

        // Repositories
        private IPizzaRepository? _pizzaRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        // Repositories loading...
        public IPizzaRepository PizzaRepository => _pizzaRepository ??= new PizzaRepository(_context);

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                    _transaction?.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
