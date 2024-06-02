﻿

using Basket.API.Data;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string UserName):IQuery<GetBasketResult>;

    public record GetBasketResult(ShoppingCart ShoppingCart);


    public class GetBasketQueryHandler(IBasketRepository basketRepository) : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var shopingCart = await basketRepository.GetBasketAsync(request.UserName, cancellationToken);
            return (new GetBasketResult(shopingCart));
        }
    }
}
