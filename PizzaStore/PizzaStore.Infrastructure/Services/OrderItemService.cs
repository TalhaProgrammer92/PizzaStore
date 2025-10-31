using AutoMapper;
using PizzaStore.ApplicationCore.DTOs.OrderItemDTO;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.ApplicationCore.Interfaces.Services;
using PizzaStore.Domain.Entities.OrderItem;

namespace PizzaStore.Infrastructure.Services
{
    public class OrderItemService : GeneralService<OrderItem, OrderItemDto>, IOrderItemService
    {
        public OrderItemService(IGeneralRepository<OrderItem> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}
