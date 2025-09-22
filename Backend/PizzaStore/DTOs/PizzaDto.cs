using PizzaStore.Enums;

namespace PizzaStore.DTOs
{
    public class PizzaDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public PizzaSize size { get; set; }
    }
}
