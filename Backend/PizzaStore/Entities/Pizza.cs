using System.ComponentModel.DataAnnotations;
using PizzaStore.Enums;

namespace PizzaStore.Entities
{
    public class Pizza
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public PizzaSize Size { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedAt { get; set; }
    }
}
