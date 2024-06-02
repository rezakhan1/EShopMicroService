
using Basket.API.Data;
using Discount.Grpc;


namespace Basket.API.Basket.StoreBasket
{
    public record StorebBasketCommand(ShoppingCart Cart) :ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidation: AbstractValidator<StorebBasketCommand>
    {
        public StoreBasketCommandValidation()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }

    public class StoreBasketCommandHanlder(IBasketRepository basketRepository,
        DiscountProtoService.DiscountProtoServiceClient discountProto) : ICommandHandler<StorebBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StorebBasketCommand command, CancellationToken cancellationToken)
        {
            ShoppingCart cart = command.Cart;
             await DeductDiscount(cart, cancellationToken).ConfigureAwait(false);
            await basketRepository.StoreBasketAsyn(cart, cancellationToken);


            return new StoreBasketResult(cart.UserName);
        }

        private async Task DeductDiscount(ShoppingCart shoppingCart, CancellationToken cancellationToken)
        {
            foreach (var item in shoppingCart.Items)
            {
                var coupon = await discountProto.GetDiscountAsync(
                    new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;
            }
        }
    }
}
