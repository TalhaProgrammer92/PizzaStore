using PizzaStore.Domain.Entities.User;

namespace PizzaStore.ApplicationCore.Interfaces.Services
{
    public interface IAuthService
    {
        Task<User?> AuthenticateAsync(string username, string password);
    }
}
