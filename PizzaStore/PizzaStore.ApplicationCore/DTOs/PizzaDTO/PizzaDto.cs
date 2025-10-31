using PizzaStore.Domain.Enums;

namespace PizzaStore.ApplicationCore.DTOs.PizzaDTO
{
    public class PizzaDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Size { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public Guid PizzaVarietyId { get; set; }
    }
}
