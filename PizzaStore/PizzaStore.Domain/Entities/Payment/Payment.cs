using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaStore.Domain.Enums;

namespace PizzaStore.Domain.Entities.Payment;

public class Payment : EntityBase
{
    [Column(TypeName = "decimal(18,2)")]
    public required decimal Amount { get; set; }
    [Required]
    public PaymentMethod PaymentMethod { get; set; }
    public bool IsSuccessful { get; set; }
    
    [Required]
    public Guid OrderId { get; set; }
    [Required]
    public virtual Order.Order Order {
        get;
        set;
    }
}
