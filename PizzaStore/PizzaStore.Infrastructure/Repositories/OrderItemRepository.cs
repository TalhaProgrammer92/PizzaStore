using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.Domain.Entities.OrderItem;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure.Repositories
{
    public class OrderItemRepository : GeneralRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(PizzaStoreDbContext context) : base(context)
        {
        }
    }
}
