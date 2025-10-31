namespace PizzaStore.ApplicationCore.DTOs.OrderDTO
{
    public class OrderDto : BaseDto
    {
        public decimal TotalAmount { get; set; } = 0;
        public Guid UserId { get; set; }
    }
}
