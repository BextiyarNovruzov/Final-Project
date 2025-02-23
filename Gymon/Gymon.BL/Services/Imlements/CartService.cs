using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.Cart;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace Gymon.BL.Services.Imlements;

public class CartService : ICartService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CartService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    private List<CartItem> GetCartItemsFromSession()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        var cartItems = session.GetString("CartItems");
        return string.IsNullOrEmpty(cartItems) ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cartItems);
    }

    private void SaveCartItemsToSession(List<CartItem> cartItems)
    {
        var session = _httpContextAccessor.HttpContext.Session;
        session.SetString("CartItems", JsonConvert.SerializeObject(cartItems));
    }

    public void AddToCart(CartItem dto)
    {
        var cartItems = GetCartItemsFromSession();
        var existingItem = cartItems.FirstOrDefault(ci => ci.ProductId == dto.ProductId);
        if (existingItem != null)
        {
            existingItem.Quantity += dto.Quantity; // Mevcut ürünü güncelle
        }
        else
        {
            cartItems.Add(dto); // Yeni ürün ekle
        }
        SaveCartItemsToSession(cartItems); // Güncellenmiş sepeti session'a kaydet
    }

    public void RemoveFromCart(int productId)
    {
        var cartItems = GetCartItemsFromSession();
        var itemToRemove = cartItems.FirstOrDefault(ci => ci.ProductId == productId);
        if (itemToRemove != null)
        {
            cartItems.Remove(itemToRemove); // Ürünü sepetten kaldır
        }
        SaveCartItemsToSession(cartItems); // Güncellenmiş sepeti session'a kaydet
    }

    public void UpdateCartItem(CartItem dto)
    {
        var cartItems = GetCartItemsFromSession();
        var existingItem = cartItems.FirstOrDefault(ci => ci.ProductId == dto.ProductId);
        if (existingItem != null)
        {
            existingItem.Quantity = dto.Quantity; // Ürün miktarını güncelle
        }
        SaveCartItemsToSession(cartItems); // Güncellenmiş sepeti session'a kaydet
    }

    public List<CartItem> GetCartItems()
    {
        return GetCartItemsFromSession(); // Sepetteki ürünleri getir
    }

    public void ClearCart()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        session.Remove("CartItems"); // Sepeti temizle
    }
}