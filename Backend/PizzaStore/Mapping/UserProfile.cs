using AutoMapper;
using PizzaStore.DTOs;
using PizzaStore.Entities;

namespace PizzaStore.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
