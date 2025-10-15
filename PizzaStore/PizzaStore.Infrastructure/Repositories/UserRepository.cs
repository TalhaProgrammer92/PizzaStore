using Microsoft.EntityFrameworkCore;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.Domain.Entities.User;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PizzaStoreDbContext _db;
        public UserRepository(PizzaStoreDbContext db) => _db = db;

        public async Task<User?> GetByUsernameAsync(string username) =>
            await _db.Users.FirstOrDefaultAsync(u => u.Username == username);

        public async Task AddAsync(User user) => await _db.Users.AddAsync(user);
        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}
