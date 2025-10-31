using PizzaStore.Domain.Entities.Order;
using PizzaStore.Domain.Entities.Pizza;

namespace PizzaStore.ApplicationCore.DTOs.OrderItemDTO
{
    public class OrderItemDto : BaseDto
    {
        public int Quantity { get; set; } = 0;
        public decimal UnitPrice { get; set; } = 0;

        public Guid OrderId { get; set; }
        public Guid PizzaId { get; set; }
    }
}
