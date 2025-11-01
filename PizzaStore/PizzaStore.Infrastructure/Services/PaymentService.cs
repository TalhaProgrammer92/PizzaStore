using AutoMapper;
using PizzaStore.ApplicationCore.DTOs.PaymentDTO;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.ApplicationCore.Interfaces.Services;
using PizzaStore.Domain.Entities.Payment;

namespace PizzaStore.Infrastructure.Services;

public class PaymentService : GeneralService<Payment, PaymentDto>, IPaymentService
{
    public PaymentService(IGeneralRepository<Payment> repo, IMapper mapper) : base(repo, mapper)
    {
        
    }
}