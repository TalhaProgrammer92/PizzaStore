using PizzaStore.Domain.Entities.Cart;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure.Repositories
{
    public class CartRepository : GeneralRepository<Cart>
    {
        public CartRepository(PizzaStoreDbContext context) : base(context)
        {
        }
    }
}
