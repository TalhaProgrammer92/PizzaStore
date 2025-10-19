using PizzaStore.ApplicationCore.DTOs.LoginDto;
using PizzaStore.ApplicationCore.DTOs.RegisterDto;
using PizzaStore.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore.ApplicationCore.Interfaces.Services
{
    public interface IAuthService
    {
        //Task<AuthResult> RegisterAsync(RegisterDto dto);
        //Task<AuthResult> LoginAsync(LoginDto dto);
        Task<User?> AuthenticateAsync(string username, string password);
    }
}
