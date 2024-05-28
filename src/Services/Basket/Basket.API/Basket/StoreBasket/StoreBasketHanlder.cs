
namespace Basket.API.Basket.StoreBasket
{
    public record StorebBasketCommand(ShoppingCart Cart):ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidation: AbstractValidator<StorebBasketCommand>
    {
        public StoreBasketCommandValidation()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }

    public class StoreBasketCommandHanlder : ICommandHandler<StorebBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StorebBasketCommand request, CancellationToken cancellationToken)
        {
            ShoppingCart cart = request.Cart;

            return new StoreBasketResult("Reza");
        }
    }
}
