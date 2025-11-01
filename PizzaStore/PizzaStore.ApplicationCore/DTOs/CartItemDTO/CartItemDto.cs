namespace PizzaStore.ApplicationCore.DTOs.CartItemDTO
{
    public class CartItemDto : BaseDto
    {
        public Guid CartId { get; set; }
        public Guid PizzaId { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
