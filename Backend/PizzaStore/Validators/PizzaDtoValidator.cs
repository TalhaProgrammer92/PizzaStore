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
            
            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("Pizza description can not exceed 500 characters");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Pizza price is required")
                .GreaterThanOrEqualTo(0).WithMessage("Pizza price can not be negative");
            
            RuleFor(p => p.Size)
                .NotEmpty().WithMessage("Pizza size is required")
                .Must(size => Enum.IsDefined(typeof(PizzaSize), size)).WithMessage("Invalid pizza size selected! Options: Small-0, Medium-1, Large-2, ExtraLarge-3");

            RuleFor(p => p.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Pizza discount can not be negative");
            
            RuleFor(p => p.DiscountPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Pizza discount price can not be negative");

            RuleFor(p => p.IsAvailable)
                .NotNull().WithMessage("Pizza availability status is required");

            RuleFor(p => p.CreatedAt)
                .NotEmpty().WithMessage("Pizza creation date-time is required");
        }
    }
}
