
using Basket.API.Exceptions;
using Marten;

namespace Basket.API.Data
{
    public class BasketRepository(IDocumentSession session) : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
           var basket = await session.LoadAsync<ShoppingCart>(userName, cancellationToken);
            return basket is null ?throw new  BasketNotFoundException(userName): basket;
        }

        public async Task<ShoppingCart> StoreBasketAsyn(ShoppingCart ShoppingCart, CancellationToken cancellationToken = default)
        {
            session.Store(ShoppingCart);
            await session.SaveChangesAsync();
            return ShoppingCart;
        }
        public async Task<bool> DeleteBasketAsyn(string userName, CancellationToken cancellationToken = default)
        {
            session.Delete<ShoppingCart>(userName);
           await  session.SaveChangesAsync();
            return true;
        }
    }
}
