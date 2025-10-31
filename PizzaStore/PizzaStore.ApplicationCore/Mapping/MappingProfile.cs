using AutoMapper;
using PizzaStore.ApplicationCore.DTOs.OrderDTO;
using PizzaStore.ApplicationCore.DTOs.PizzaDTO;
using PizzaStore.ApplicationCore.DTOs.PizzaVarietyDTO;
using PizzaStore.ApplicationCore.DTOs.UserDTO;
using PizzaStore.Domain.Entities.Order;
using PizzaStore.Domain.Entities.Pizza;
using PizzaStore.Domain.Entities.PizzaVariety;
using PizzaStore.Domain.Entities.User;

namespace PizzaStore.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /* <---- Mapping configurations ----> */
            CreateMap<Pizza, PizzaDto>()
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size.ToString()));

            CreateMap<PizzaVariety, PizzaVarietyDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
        }
    }
}
