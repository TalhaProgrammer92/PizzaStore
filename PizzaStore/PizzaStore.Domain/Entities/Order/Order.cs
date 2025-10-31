using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Entities.Order
{
    public class Order : EntityBase
    {

        [Column(TypeName = "decimal(18,2)")]
        public required decimal TotalAmount { get; set; }

        [Required]
        public Guid UserId { get; set; }
        
        [Required]
        public User.User User { get; set; }
    }
}
