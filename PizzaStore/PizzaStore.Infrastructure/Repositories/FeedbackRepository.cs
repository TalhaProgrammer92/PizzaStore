using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.Domain.Entities.Feedback;
using PizzaStore.Infrastructure.Data;

namespace PizzaStore.Infrastructure.Repositories
{
    public class FeedbackRepository : GeneralRepository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(PizzaStoreDbContext context) : base(context)
        {
        }
    }
}
