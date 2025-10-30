namespace PizzaStore.ApplicationCore.Interfaces.Repositories
{
    public interface IGeneralRepository<T> where T : class
    {
        Task AddAsync(T obj);
        Task<T> GetAsync();
        Task<T> UpdateAsync(T obj);
        Task RemoveAsync(Guid id);

        Task SaveChangesAsync();
    }
}
