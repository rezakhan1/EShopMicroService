namespace Basket.API.Data
{
    public interface IBasketRepository
    {
        Task<ShoppingCart>  GetBasketAsync(string userName, CancellationToken cancellationToken=default);

        Task<ShoppingCart> StoreBasketAsyn(ShoppingCart ShoppingCart, CancellationToken cancellationToken = default);


        Task<bool> DeleteBasketAsyn(string userName, CancellationToken cancellationToken = default);
    }
}
