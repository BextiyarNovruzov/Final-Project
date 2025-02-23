using Gymon.Core.Entities.ProductAttributies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string CoverImage { get; set; } = null!;
        public decimal Discount { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }
        public decimal DiscountedPrice => SellPrice - (SellPrice * (Discount / 100));
        public int CategoryId { get; set; } 
        public Category Category { get; set; }
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public List<Review> Reviews { get; set; } = new List<Review>(); // New navigation property
        public ICollection<ProductAttribute> ProductAttributes { get; set; } // Navigation 
    }
}
