using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.Domain.Entities.Order;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure.Repositories
{
    public class OrderRepository : GeneralRepository<Order>, IOrderRepository
    {
        public OrderRepository(PizzaStoreDbContext context) : base(context)
        {
        }
    }
}
