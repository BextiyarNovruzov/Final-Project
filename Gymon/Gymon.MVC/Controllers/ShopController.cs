using AutoMapper;
using Gymon.BL.Services.Imlements;
using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.Cart;
using Gymon.BL.ViewModels.ProductVMs;
using Gymon.BL.ViewModels.Review;
using Gymon.Core.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Stripe;
using System.Drawing.Printing;
using System.Security.Claims;
using System.Text.Json;
using CartItem = Gymon.BL.ViewModels.Cart.CartItem;

namespace Gymon.MVC.Controllers
{
    public class ShopController(IProductService _productService, ICategoryService _categoryService, IReviewService _reviewService, IMapper _mapper, IOrderService _orderService) : Controller
    {
        private const string CartSessionKey = "Cart";

        public async Task<IActionResult> Product(int page = 1)
        {
            var viewModel = await _productService.GetProductsAsync(page);
            return View(viewModel);
        }


        public async Task<IActionResult> ProductDetails(int id)
        {
            var productDetails = await _productService.GetProductDetailsAsync(id);
            if (productDetails == null)
            {
                return NotFound(); // Handle the case where the product is not found
            }

            // Set the UserId
            productDetails.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Initialize lists to avoid null references
            productDetails.Reviews ??= new List<ReviewViewModel>();
            productDetails.Images ??= new List<string>();
            productDetails.Categories ??= new List<Category>();

            return View(productDetails);
        }



        [HttpPost]
        public IActionResult SubmitReview(ReviewViewModel reviewModel)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("ProductDetails", new { id = reviewModel.ProductId });
            }

            var review = new Core.Entities.Review
            {
                ProductId = reviewModel.ProductId,
                UserId = reviewModel.UserId,
                ReviewerName = reviewModel.ReviewerName,
                Comment = reviewModel.Comment,
                Rating = reviewModel.Rating,
                CreatedAt = DateTime.Now
            };

            _productService.AddReview(reviewModel.ProductId, review);

            return RedirectToAction("ProductDetails", new { id = reviewModel.ProductId });
        }





        // 📌 1. ÜRÜNÜ SEPETE EKLE
        public IActionResult AddToCart(int productId, int quantity)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            var existingItem = cart.FirstOrDefault(ci => ci.ProductId == productId);

            if (existingItem == null)
            {
                cart.Add(new CartItem { ProductId = productId, Quantity = quantity });
            }
            else
            {
                existingItem.Quantity += quantity;
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction("Cart");
        }

        // 📌 2. SEPETİ GÖRÜNTÜLE
        public async Task<IActionResult> Cart()
        {
            var cart = GetCartFromSession();
            var cartItems = new List<CartItemViewModel>();

            foreach (var item in cart)
            {
                var product = await _productService.GetProductByIdAsync(item.ProductId);
                if (product != null)
                {
                    cartItems.Add(new CartItemViewModel
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        CoverImage = product.CoverImage,
                        Price = product.SellPrice,
                        Quantity = item.Quantity,
                        TotalPrice = product.DiscountedPrice // Toplam fiyat
                    });
                }
            }

            var cartViewModel = new CartViewModel { Items = cartItems };
            return View(cartViewModel);
        }

        // 📌 SEPETTEN ÜRÜN SİL
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCartFromSession();
            var item = cart.FirstOrDefault(c => c.ProductId == productId);

            if (item != null)
            {
                cart.Remove(item);
                SaveCartToSession(cart);
            }
            return RedirectToAction("Cart");
        }

        // 📌 SESSION YÖNETİMİ
        private List<CartItem> GetCartFromSession()
        {
            return HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
        }

        private void SaveCartToSession(List<CartItem> cart)
        {
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }

        //private void ClearCartSession()
        //{
        //    HttpContext.Session.Remove("Cart");
        //}


        // 📌 4. SİPARİŞİ TAMAMLA

        //public IActionResult Checkout()
        //{
        //    return View();
        //}
        //[HttpPost]

        //public async Task<IActionResult> Checkout(string stripeToken)
        //{
        //    var cart = GetCartFromSession();
        //    if (!cart.Any())
        //    {
        //        return RedirectToAction("Cart");
        //    }

        //    // Kullanıcı kimliğini oturumdan alın
        //    int userId = HttpContext.User.Identity.IsAuthenticated
        //        ? Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
        //        : 1; // Varsayılan kullanıcı kimliği

        //    // Toplam fiyatı hesapla
        //    decimal totalPrice = 0;
        //    var cartItemsViewModel = new List<CartItemViewModel>();

        //    foreach (var item in cart)
        //    {
        //        var product = await _productService.GetProductByIdAsync(item.ProductId);
        //        if (product != null)
        //        {
        //            totalPrice += product.SellPrice * item.Quantity;
        //            cartItemsViewModel.Add(new CartItemViewModel
        //            {
        //                ProductId = product.Id,
        //                ProductName = product.Name,
        //                CoverImage = product.CoverImage,
        //                Price = product.SellPrice,
        //                Quantity = item.Quantity,
        //                TotalPrice = product.SellPrice * item.Quantity
        //            });
        //        }
        //    }

        //    // Stripe ile ödeme işlemi
        //    var options = new ChargeCreateOptions
        //    {
        //        Amount = (long)(totalPrice * 100), // Stripe, ödemeleri kuruş cinsinden alır
        //        Currency = "usd",
        //        Source = stripeToken,
        //        Description = "Order from Gymon",
        //    };

        //    var service = new ChargeService();

        //    // Stripe API anahtarını yapılandır
        //    StripeConfiguration.ApiKey = "sk_test_51QvcsgDipqoNh4omlQIf4UFsqdneLatR3bg6odQrJ84FIyK4dFb0isBc4MZ6igGk4TSZkrx5Y3Cgm8uky5TzFFx000XO1HILjb"; // Gizli anahtarınızı buradan alın

           
        //        // Ödeme talebini oluştur
        //        Charge charge = await service.CreateAsync(options); // Asenkron çağrı

        //        // Sipariş oluştur
        //        if (charge.Status == "succeeded")
        //        {
        //            var order = new Order
        //            {
        //                UserId = userId,
        //                TotalPrice = totalPrice,
        //                OrderDate = DateTime.Now,
        //                OrderDetails = cartItemsViewModel.Select(item => new OrderDetail
        //                {
        //                    ProductId = item.ProductId,
        //                    Quantity = item.Quantity,
        //                    Price = item.Price
        //                }).ToList()
        //            };

        //            // Siparişi veritabanına kaydet
        //            await _orderService.CreateOrderAsync(order);

        //            // Sepeti temizle
        //            ClearCartSession();
        //            return RedirectToAction("OrderSuccess");
        //        }

        //    return RedirectToAction("Cart");
        //}

        //public IActionResult OrderSuccess()
        //{
        //    return View();
        //}

 



    }
}
