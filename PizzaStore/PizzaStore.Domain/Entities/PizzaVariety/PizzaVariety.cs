using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Domain.Entities.PizzaVariety
{
    public class PizzaVariety : EntityBase
    {
        [Required]
        public string Name { get; set; }

        //public Size? Size { get; set; }

        public ICollection<Pizza.Pizza> Pizzas { get; set; }
    }
}
