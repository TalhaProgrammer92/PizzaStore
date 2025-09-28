using System.ComponentModel.DataAnnotations;
using PizzaStore.Enums;

namespace PizzaStore.Entities
{
    public class Pizza
    {
        [Key]
        public Guid Id { get; set; }

        public byte[]? Image { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? Discount { get; set; }
        public decimal? DiscountPrice { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;

        [Required]
        public PizzaSize Size { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
