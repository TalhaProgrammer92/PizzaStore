using FluentValidation;
using PizzaStore.DTOs;
using PizzaStore.Enums;

namespace PizzaStore.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.");
            
            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");
            
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");
            
            RuleFor(user => user.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$").When(user => !string.IsNullOrEmpty(user.PhoneNumber))
                .WithMessage("A valid phone number is required.");
            
            RuleFor(user => user.Role)
                .NotEmpty().WithMessage("Role is required.")
                .Must(size => Enum.IsDefined(typeof(Role), size)).WithMessage("Invalid role selected! Options: User-0, Admin-1");
            //.IsInEnum().WithMessage("Role must be a valid enum value.");
        }
    }
}
