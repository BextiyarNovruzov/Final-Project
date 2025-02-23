using Gymon.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;

namespace Gymon.Core.Helpers
{
    public static class SessionHelper
    {
        private const string CartSessionKey = "Cart";
        public static void SetCart(HttpContext context, List<CartItem> cart)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            string cartJson = JsonConvert.SerializeObject(cart);
            //context.Session.SetString(CartSessionKey, cartJson); // Düzgün metod
        }


        //public static List<CartItem> GetCart(HttpContext context)
        //{
        //    if (context == null) throw new ArgumentNullException(nameof(context));
        //    //string cartJson = context.Session.GetString(CartSessionKey);
        //    return string.IsNullOrEmpty(cartJson) ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
        //}

        //public static void AddToCart(HttpContext context, int productId)
        //{
        //    ValidateContext(context);
        //    var cart = GetCart(context);
        //    var item = FindCartItem(cart, productId);

        //    if (item != null)
        //    {
        //        item.Quantity++;
        //    }
        //    else
        //    {
        //        cart.Add(CreateNewCartItem(productId));
        //    }

        //    SetCart(context, cart);
        //}

        //public static void RemoveFromCart(HttpContext context, int productId)
        //{
        //    ValidateContext(context);
        //    var cart = GetCart(context);
        //    var item = FindCartItem(cart, productId);

        //    if (item != null)
        //    {
        //        cart.Remove(item);
        //        SetCart(context, cart);
        //    }
        //}

        //public static void UpdateQuantity(HttpContext context, int productId, int quantity)
        //{
        //    ValidateContext(context);
        //    var cart = GetCart(context);
        //    var item = FindCartItem(cart, productId);

        //    if (item != null)
        //    {
        //        if (quantity > 0)
        //        {
        //            item.Quantity = quantity;
        //        }
        //        else
        //        {
        //            cart.Remove(item);
        //        }
        //        SetCart(context, cart);
        //    }
        //}

        //private static void ValidateContext(HttpContext context)
        //{
        //    if (context == null) throw new ArgumentNullException(nameof(context));
        //}

        //private static CartItem FindCartItem(List<CartItem> cart, int productId)
        //{
        //    return cart.FirstOrDefault(p => p.ProductId == productId);
        //}

        //private static CartItem CreateNewCartItem(int productId)
        //{
        //    return new CartItem { ProductId = productId, Quantity = 1 };
        //}
    }
}
