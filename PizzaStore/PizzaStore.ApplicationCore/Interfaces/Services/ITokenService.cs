using System.Security.Claims;

namespace PizzaStore.ApplicationCore.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(string username);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
