using PizzaStore.Data;
using PizzaStore.Entities;
using PizzaStore.Repositories.IRepositories;

namespace PizzaStore.Repositories
{
    public class PizzaRepository : GenericRepository<Pizza>, IPizzaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PizzaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
