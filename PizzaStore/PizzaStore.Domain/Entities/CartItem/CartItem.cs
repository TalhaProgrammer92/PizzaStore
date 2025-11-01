using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Domain.Entities.CartItem
{
    public class CartItem : EntityBase
    {
        [Required]
        public Guid CartId { get; set; }
        
        [Required]
        public virtual Cart.Cart Cart { get; set; }
        
        [Required]
        public Guid PizzaId { get; set; }
        
        [Required]
        public virtual Pizza.Pizza Pizza { get; set; }

        public int Quantity { get; set; }
    }
}
