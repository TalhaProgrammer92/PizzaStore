using AutoMapper;
using PizzaStore.ApplicationCore.DTOs.PizzaDTO;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.ApplicationCore.Interfaces.Services;
using PizzaStore.Domain.Entities.Pizza;

namespace PizzaStore.Infrastructure.Services
{
    public class PizzaService : GeneralService<Pizza, PizzaDto>, IPizzaService
    {
        public PizzaService(IGeneralRepository<Pizza> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}
