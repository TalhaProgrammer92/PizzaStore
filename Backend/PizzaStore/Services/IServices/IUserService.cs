using PizzaStore.DTOs;

namespace PizzaStore.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsesAsync();
        Task<UserDto?> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(Guid id);
    }
}
