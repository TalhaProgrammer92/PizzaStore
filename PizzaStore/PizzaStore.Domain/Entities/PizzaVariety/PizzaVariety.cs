using System.ComponentModel.DataAnnotations;
using PizzaStore.Domain.Entities.Pizza;
using PizzaStore.Domain.Enums;

namespace PizzaStore.Domain.Entities.PizzaVariety
{
    public class PizzaVariety : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public Size? Size { get; set; }

        public ICollection<Pizza.Pizza> Pizzas { get; set; }
    }
}
