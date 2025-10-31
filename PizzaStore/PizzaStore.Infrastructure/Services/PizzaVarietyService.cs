using AutoMapper;
using PizzaStore.ApplicationCore.DTOs.PizzaVarietyDTO;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.Domain.Entities.PizzaVariety;

namespace PizzaStore.Infrastructure.Services
{
    public class PizzaVarietyService : GeneralService<PizzaVariety, PizzaVarietyDto>, IPizzaVarietyService
    {
        public PizzaVarietyService(IGeneralRepository<PizzaVariety> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
