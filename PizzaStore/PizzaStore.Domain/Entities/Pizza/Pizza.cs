using PizzaStore.Domain.Entities.PizzaVariety;
using PizzaStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Entities.Pizza
{
    public class Pizza : EntityBase
    {
        [Required]
        public byte[] Image { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public required decimal Price { get; set; }

        [Required]
        public Size Size { get; set; }

        [Required]
        public Guid PizzaVarietyId { get; set; }

        [Required]
        public PizzaVariety.PizzaVariety PizzaVariety { get; set; }

        public string? Description { get; set; }
    }
}
