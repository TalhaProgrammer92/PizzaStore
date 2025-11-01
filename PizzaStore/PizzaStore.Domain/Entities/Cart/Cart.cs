using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Domain.Entities.Cart
{
    public class Cart : EntityBase
    {
        [Required]
        public Guid UserId { get; set; }
        
        [Required]
        public User.User User { get; set; }

        public ICollection<CartItem.CartItem> CartItems { get; set; }
    }
}
