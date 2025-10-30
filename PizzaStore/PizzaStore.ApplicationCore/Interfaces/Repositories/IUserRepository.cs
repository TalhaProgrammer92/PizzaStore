using PizzaStore.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore.ApplicationCore.Interfaces.Repositories
{
    public interface IUserRepository : IGeneralRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        //Task AddAsync(User user);
        //Task SaveChangesAsync();
    }
}
