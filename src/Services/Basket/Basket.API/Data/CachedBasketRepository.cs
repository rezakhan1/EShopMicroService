
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace Basket.API.Data
{
    public class CachedBasketRepository(IBasketRepository basketRepository, IDistributedCache memoryCache) : IBasketRepository
    {
      

        public async Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
           var cacheBasket=await memoryCache.GetStringAsync(userName, cancellationToken);
            if (!string.IsNullOrEmpty(cacheBasket))
            {
                return JsonSerializer.Deserialize<ShoppingCart>(cacheBasket)!;
            }
          
            var shopingcart= await basketRepository.GetBasketAsync(userName, cancellationToken);
            await memoryCache.SetStringAsync(userName, JsonSerializer.Serialize(shopingcart),cancellationToken);
            return shopingcart;
        }

        public async Task<ShoppingCart> StoreBasketAsyn(ShoppingCart ShoppingCart, CancellationToken cancellationToken = default)
        {
            var shopingcart=await basketRepository.StoreBasketAsyn(ShoppingCart, cancellationToken);
            await memoryCache.SetStringAsync(ShoppingCart.UserName, JsonSerializer.Serialize(shopingcart), cancellationToken);
            return shopingcart;
        }
        public async Task<bool> DeleteBasketAsyn(string userName, CancellationToken cancellationToken = default)
        {
            await basketRepository.DeleteBasketAsyn(userName, cancellationToken);
             memoryCache.Remove(userName);
            return true;
        }
    }
}
