namespace PizzaStore.ApplicationCore.Interfaces.Repositories
{
    public interface IGeneralRepository<T> where T : class
    {
        Task<IQueryable<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> UpdateAsync(Guid id);
        Task RemoveAsync(Guid id);

        Task AddAsync(T obj);
        Task SaveChangesAsync();
    }
}
