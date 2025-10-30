using Microsoft.EntityFrameworkCore;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.Domain.Entities.User;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure.Repositories
{
    public class UserRepository : GeneralRepository<User>, IUserRepository
    {
        public UserRepository(PizzaStoreDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByUsernameAsync(string username) =>
            await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
    }
}
