using AutoMapper;
using PizzaStore.ApplicationCore.DTOs.CartDTO;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.ApplicationCore.Interfaces.Services;
using PizzaStore.Domain.Entities.Cart;

namespace PizzaStore.Infrastructure.Services
{
    public class CartService : GeneralService<Cart, CartDto>, ICartService
    {
        public CartService(IGeneralRepository<Cart> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}
