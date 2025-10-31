using AutoMapper;
using PizzaStore.ApplicationCore.DTOs.FeedbackDTO;
using PizzaStore.ApplicationCore.Interfaces.Repositories;
using PizzaStore.ApplicationCore.Interfaces.Services;
using PizzaStore.Domain.Entities.Feedback;

namespace PizzaStore.Infrastructure.Services
{
    public class FeedbackService : GeneralService<Feedback, FeedbackDto>, IFeedbackService
    {
        public FeedbackService(IGeneralRepository<Feedback> repo, IMapper mapper) : base(repo, mapper)
        {
        }
    }
}
