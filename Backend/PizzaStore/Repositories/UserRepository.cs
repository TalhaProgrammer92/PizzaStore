using PizzaStore.Data;
using PizzaStore.Entities;
using PizzaStore.Repositories.IRepositories;

namespace PizzaStore.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
