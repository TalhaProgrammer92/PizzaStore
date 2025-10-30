using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.Domain.Entities.Pizza;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure.Repositories
{
    public class PizzaRepository : GeneralRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaStoreDbContext context) : base(context)
        {
        }
    }
}
