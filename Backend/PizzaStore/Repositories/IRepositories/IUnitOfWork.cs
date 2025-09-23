using Microsoft.EntityFrameworkCore.Storage;

namespace PizzaStore.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPizzaRepository PizzaRepository { get; }

        // Tasks
        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
