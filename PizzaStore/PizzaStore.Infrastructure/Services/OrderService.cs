using AutoMapper;
using PizzaStore.ApplicationCore.DTOs.OrderDTO;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.ApplicationCore.Interfaces.Services;
using PizzaStore.Domain.Entities.Order;

namespace PizzaStore.Infrastructure.Services
{
    public class OrderService : GeneralService<Order, OrderDto>, IOrderService
    {
        public OrderService(IGeneralRepository<Order> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}
