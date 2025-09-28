using PizzaStore.Enums;

namespace PizzaStore.DTOs
{
    public class PizzaDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[]? Image { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public decimal? DiscountPrice { get; set; }
        public bool IsAvailable { get; set; }
        public PizzaSize Size { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
