using FluentValidation;
using PizzaStore.DTOs;
using PizzaStore.Enums;

namespace PizzaStore.Validators
{
    public class PizzaDtoValidator : AbstractValidator<PizzaDto>
    {
        public PizzaDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Pizza name is required");
            
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Pizza price is required")
                .GreaterThanOrEqualTo(0).WithMessage("Pizza price can not be negative");
            
            RuleFor(p => p.Size)
                .NotEmpty().WithMessage("Pizza size is required")
                .Must(size => Enum.IsDefined(typeof(PizzaSize), size)).WithMessage("Invalid pizza size selected! Options: Small, Medium, Large, ExtraLarge");
            
            RuleFor(p => p.CreatedAt)
                .NotEmpty().WithMessage("Pizza creation date-time is required");
        }
    }
}
