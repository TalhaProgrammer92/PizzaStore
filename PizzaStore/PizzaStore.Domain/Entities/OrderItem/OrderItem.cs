using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Domain.Entities.OrderItem
{
    public class OrderItem : EntityBase
    {
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Required]
        public Guid OrderId { get; set; }
        public Order.Order Order { get; set; }

        [Required]
        public Guid PizzaId { get; set; }
        public Pizza.Pizza Pizza { get; set; }
    }
}
