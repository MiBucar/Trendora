using Wardrobe.Models.ViewModels;
using Wardrobe.Services.Interfaces;
using Blazored.LocalStorage;
using Wardrobe.Common;
using Microsoft.AspNetCore.Components.Web;


namespace Wardrobe.Services.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        public event Action OnCartChange;

        private readonly ILocalStorageService _localStorage;

        private void NotifyOnCartChanged() => OnCartChange?.Invoke();

        public ShoppingCartService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task DecrementCart(ShoppingCartItem cartToRemove)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCartItem>>(SD.ShoppingCart);

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductId == cartToRemove.ProductId)
                {
                    if (cart[i].Count == 1 || cart[i].Count == 0) 
                    {
                        cart.Remove(cart[i]);
                    }
                    else
                    {
                        cart[i].Count -= cartToRemove.Count;
                    }
                }
            }

            await _localStorage.SetItemAsync(SD.ShoppingCart, cart);
            NotifyOnCartChanged();
        }

        public async Task DeleteCart(int productId)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCartItem>>(SD.ShoppingCart);
            var cartToRemove = cart.FirstOrDefault(x => x.ProductId == productId);
            if (cartToRemove != null)
                cart.Remove(cartToRemove);
            await _localStorage.SetItemAsync(SD.ShoppingCart, cart);
            NotifyOnCartChanged();
        }

        public async Task IncrementCart(ShoppingCartItem cartToAdd)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCartItem>>(SD.ShoppingCart);
            bool itemInCart = false;            

            if (cart == null)
            {
                cart = new List<ShoppingCartItem>();
            }

            foreach (var item in cart)
            {
                if (item.ProductId == cartToAdd.ProductId && item.Size == cartToAdd.Size)
                {
                    itemInCart = true;
                    item.Count += cartToAdd.Count;
                    item.ProductPrice = cartToAdd.ProductPrice;
                    item.Size = cartToAdd.Size;
                }
            }

            if (!itemInCart)
            {
                cart.Add(new ShoppingCartItem()
                {
                    ProductId = cartToAdd.ProductId,
                    Count = cartToAdd.Count,
                    ProductPrice = cartToAdd.ProductPrice,
                    Size = cartToAdd.Size
                });
            }

            await _localStorage.SetItemAsync(SD.ShoppingCart, cart);
            NotifyOnCartChanged();
        }

        public async Task<int> GetNumberOfProductsInCart()
        {
            var productsInCart = await _localStorage.GetItemAsync<List<ShoppingCartItem>>(SD.ShoppingCart);
            return productsInCart.Count();
        }
    }
}
