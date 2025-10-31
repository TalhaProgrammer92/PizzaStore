using AutoMapper;
using PizzaStore.ApplicationCore.DTOs.UserDTO;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.ApplicationCore.Interfaces.Services;
using PizzaStore.Domain.Entities.User;

namespace PizzaStore.Infrastructure.Services
{
    public class UserService : GeneralService<User, UserDto>, IUserService
    {
        public UserService(IGeneralRepository<User> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}
