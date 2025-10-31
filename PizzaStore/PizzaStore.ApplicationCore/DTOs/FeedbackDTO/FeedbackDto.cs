namespace PizzaStore.ApplicationCore.DTOs.FeedbackDTO
{
    public class FeedbackDto : BaseDto
    {
        public Guid UserId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? Rating { get; set; } = null;
    }
}
