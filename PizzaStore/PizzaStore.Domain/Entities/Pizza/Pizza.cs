using PizzaStore.Domain.Enums;
using PizzaStore.Domain.Entities.PizzaVariety;
using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Domain.Entities.Pizza
{
    public class Pizza : EntityBase
    {
        [Required]
        public byte[] Image { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Size Size { get; set; }

        [Required]
        public PizzaVariety.PizzaVariety PizzaVariety { get; set; }

        public string? Description { get; set; }
    }
}
