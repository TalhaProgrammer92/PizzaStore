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
        public string? Description { get; set; }

        [Required]
        public Guid PizzaVarietyId { get; set; }

        [Required]
        public virtual PizzaVariety.PizzaVariety PizzaVariety { get; set; }

        public virtual ICollection<OrderItem.OrderItem> OrderItems { get; set; }
        public virtual ICollection<CartItem.CartItem> CartItems { get; set; }
    }
}
