using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.ProductVMs
{
    public class ProductItemsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SellPrice { get; set; }
        public decimal Discount { get; set; } // Yüzde olarak indirim
        public string CoverImage { get; set; }
        public double Rating { get; set; }
        public decimal DiscountedPrice => SellPrice - (SellPrice * (Discount / 100));
    }

}
