using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.Domain.Entities.Payment;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure.Repositories;

public class PaymentRepository : GeneralRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(PizzaStoreDbContext context) : base(context)
    {
        
    }
}