using Microsoft.EntityFrameworkCore;
using PizzaStore.ApplicationCore.Interfaces.Services;
using PizzaStore.Domain.Entities.User;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly PizzaStoreDbContext _context;

        public AuthService(PizzaStoreDbContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            // Later I’ll replace this with hashed password verification
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);
        }
    }
}
