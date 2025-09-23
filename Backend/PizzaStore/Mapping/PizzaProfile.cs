using PizzaStore.DTOs;
using PizzaStore.Entities;
using AutoMapper;

namespace PizzaStore.Mapping
{
    public class PizzaProfile : Profile
    {
        public PizzaProfile()
        {
            CreateMap<Pizza, PizzaDto>().ReverseMap();
        }
    }
}
