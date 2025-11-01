using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Domain.Entities.Feedback
{
    public class Feedback : EntityBase
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public User.User User { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, 5)]
        public int? Rating { get; set; }
    }
}
