namespace PetFoodShop.Cart.Application.Commands.CheckoutCart
{
    using FluentValidation;

    public class CheckoutCartCommandValidator : AbstractValidator<CheckoutCartCommand>
    {
        public CheckoutCartCommandValidator()
        {
            this.RuleFor(x => x.Cart)
                .NotNull()
                .NotEmpty();

            this.RuleFor(x => x.DeliveryAddress)
                .NotNull()
                .NotEmpty();
        }
    }
}
