using PizzaStore.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        public Role Role { get; set; } = Role.User;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
