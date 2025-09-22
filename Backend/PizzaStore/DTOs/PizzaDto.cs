using PizzaStore.Enums;

namespace PizzaStore.DTOs
{
    public class PizzaDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public PizzaSize Size { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public DateTime? UpdatedAt { get; set; }
    }

    public class PizzaUpdateDto : PizzaDto
    {
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
