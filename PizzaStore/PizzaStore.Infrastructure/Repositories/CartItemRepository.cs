using PizzaStore.Domain.Entities.CartItem;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure.Repositories
{
    public class CartItemRepository : GeneralRepository<CartItem>
    {
        public CartItemRepository(PizzaStoreDbContext context) : base(context)
        {
        }
    }
}
