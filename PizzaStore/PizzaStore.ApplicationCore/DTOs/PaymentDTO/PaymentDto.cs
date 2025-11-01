namespace PizzaStore.ApplicationCore.DTOs.PaymentDTO;

public class PaymentDto : BaseDto
{
    public required decimal Amount { get; set; } = 0;
    public string PaymentMethod { get; set; } = String.Empty;
    public bool IsSuccessful { get; set; }
    public Guid OrderId { get; set; }
}