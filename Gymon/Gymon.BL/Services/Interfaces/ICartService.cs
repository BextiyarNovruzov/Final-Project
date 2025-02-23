using Gymon.BL.ViewModels.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Interfaces
{
    public interface ICartService
    {
            void AddToCart(CartItem dto);
            void RemoveFromCart(int productId);
            void UpdateCartItem(CartItem dto);
            List<CartItem> GetCartItems();
            void ClearCart();
        }
}
