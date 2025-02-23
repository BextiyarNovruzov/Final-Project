using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.Checkout
{
    public class CartItemViewModel
    {
        public string ProductName { get; set; }  // Ürün adı
        public string CoverImage { get; set; }   // Ürün resminin URL'si
        public decimal Price { get; set; }        // Ürün fiyatı
        public int Quantity { get; set; }         // Ürün miktarı
        public decimal TotalPrice => Price * Quantity; // Toplam fiyat (fiyat * miktar)
    }
}
