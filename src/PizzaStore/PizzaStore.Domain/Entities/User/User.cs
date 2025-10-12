using PizzaStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Domain.Entities.User
{
    public class User : EntityBase
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Role Role { get; set; } // e.g., "Customer", "Admin"
    }
}
