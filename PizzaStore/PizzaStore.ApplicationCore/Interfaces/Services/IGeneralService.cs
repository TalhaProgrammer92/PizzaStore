namespace PizzaStore.ApplicationCore.Interfaces.Services
{
    public interface IGeneralService<TDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(Guid id);
        Task AddAsync(TDto dto);
        Task UpdateAsync(Guid id, TDto dto);
        Task RemoveAsync(Guid id);
    }
}
