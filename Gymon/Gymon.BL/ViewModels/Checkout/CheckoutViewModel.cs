using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.Checkout
{

    public class CheckoutViewModel
    {
        public string Name { get; set; }        // Kullanıcının adı
        public string Email { get; set; }       // Kullanıcının e-posta adresi
        public string Address { get; set; }     // Kullanıcının adresi
        public string City { get; set; }        // Kullanıcının şehri
        public string ZipCode { get; set; }     // Kullanıcının posta kodu
        public string Phone { get; set; }       // Kullanıcının telefon numarası
        public string PaymentMethod { get; set; } // Ödeme yöntemi (örneğin, kredi kartı)
        public string StripeToken { get; set; } // Stripe ödeme işlemi için token
        public List<CartItemViewModel> CartItems { get; set; } // Kullanıcının sepetindeki ürünler
        public decimal Subtotal { get; set; }   // Alt toplam
        public decimal Total { get; set; }      // Toplam tutar

        public CheckoutViewModel()
        {
            CartItems = new List<CartItemViewModel>();
        }
    }
}
