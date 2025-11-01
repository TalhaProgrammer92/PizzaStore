using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Domain.Entities.Cart
{
    public class Cart : EntityBase
    {
        [Required]
        public Guid UserId { get; set; }
        
        [Required]
        public virtual User.User User { get; set; }

        public virtual ICollection<CartItem.CartItem> CartItems { get; set; }
    }
}
