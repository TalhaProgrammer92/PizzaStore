using AutoMapper;
using PizzaStore.ApplicationCore.DTOs.CartItemDTO;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.Domain.Entities.CartItem;

namespace PizzaStore.Infrastructure.Services
{
    public class CartItemService : GeneralService<CartItem, CartItemDto>
    {
        public CartItemService(IGeneralRepository<CartItem> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}
