

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName):IQuery<GetBasketResult>;

    public record GetBasketResult(ShoppingCart ShoppingCart);


    public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            //TO DO : Get basket from repso

            return (new GetBasketResult(new ShoppingCart("Name")));
        }
    }
}
