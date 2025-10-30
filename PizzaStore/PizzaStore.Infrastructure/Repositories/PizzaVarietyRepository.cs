using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.Domain.Entities.PizzaVariety;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure.Repositories
{
    public class PizzaVarietyRepository : GeneralRepository<PizzaVariety>, IPizzaVarietyRepository
    {
        public PizzaVarietyRepository(PizzaStoreDbContext context) : base(context)
        {
        }
    }
}
