using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Entities
{
    public class Payment : BaseEntity
    {
        public int OrderId { get; set; }
        public OrderDetail Order { get; set; }

        // Stripe ödəniş məlumatları
        public string StripePaymentIntentId { get; set; } // Stripe PaymentIntent ID
        public string StripePaymentMethodId { get; set; } // Stripe PaymentMethod ID
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; } // Payment status (e.g., "succeeded", "failed")
        public string PaymentMethod { get; set; } // Ödəniş metodu (Kredit kartı, bank köçürməsi)
        public DateTime PaymentDate { get; set; }
    }
}