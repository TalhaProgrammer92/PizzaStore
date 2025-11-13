using AutoMapper;
using PizzaStore.ApplicationCore.DTOs.CartDTO;
using PizzaStore.ApplicationCore.DTOs.CartItemDTO;
using PizzaStore.ApplicationCore.DTOs.FeedbackDTO;
using PizzaStore.ApplicationCore.DTOs.OrderDTO;
using PizzaStore.ApplicationCore.DTOs.OrderItemDTO;
using PizzaStore.ApplicationCore.DTOs.PaymentDTO;
using PizzaStore.ApplicationCore.DTOs.PizzaDTO;
using PizzaStore.ApplicationCore.DTOs.PizzaVarietyDTO;
using PizzaStore.ApplicationCore.DTOs.UserDTO;
using PizzaStore.Domain.Entities.Cart;
using PizzaStore.Domain.Entities.CartItem;
using PizzaStore.Domain.Entities.Feedback;
using PizzaStore.Domain.Entities.Order;
using PizzaStore.Domain.Entities.OrderItem;
using PizzaStore.Domain.Entities.Payment;
using PizzaStore.Domain.Entities.Pizza;
using PizzaStore.Domain.Entities.PizzaVariety;
using PizzaStore.Domain.Entities.User;
using PizzaStore.Domain.Enums;

namespace PizzaStore.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /* <---- Mapping configurations ----> */
            //CreateMap<Pizza, PizzaDto>()
            //    .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size.ToString()));

            CreateMap<Pizza, PizzaDto>()
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size.ToString()))
                .ForMember(dest => dest.PizzaVarietyName, opt => opt.MapFrom(src => src.PizzaVariety.Name))
                .ReverseMap()
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => Enum.Parse<Size>(src.Size)))
                .ForMember(dest => dest.PizzaVariety, opt => opt.Ignore()); // Because it's handled by FK


            CreateMap<PizzaVariety, PizzaVarietyDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            
            CreateMap<Payment, PaymentDto>().ReverseMap()
                .ForMember(dest => dest.PaymentMethod,
                    opt => opt.MapFrom(src => src.PaymentMethod.ToString()));

            CreateMap<Cart, CartDto>().ReverseMap();

            CreateMap<CartItem, CartItemDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

            CreateMap<Feedback, FeedbackDto>().ReverseMap();
        }
    }
}
