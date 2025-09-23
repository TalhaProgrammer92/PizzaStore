using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Entities;
using PizzaStore.Enums;
using PizzaStore.Repositories.IRepositories;
using System.Drawing;

namespace PizzaStore.Repositories
{
    public class PizzaRepository : GenericRepository<Pizza>, IPizzaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PizzaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
