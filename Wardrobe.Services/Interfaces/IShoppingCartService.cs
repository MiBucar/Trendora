using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Models.ViewModels;

namespace Wardrobe.Services.Interfaces
{
    public interface IShoppingCartService
    {
        public Task DecrementCart(ShoppingCartItem shoppingCart);
        public Task IncrementCart(ShoppingCartItem shoppingCart);
        public Task DeleteCart(int productId);
    }
}
