using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Entities.ProductAttributies
{
    public class ProductAttribute : BaseEntity
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string? Brands { get; set; }
        public string? Models { get; set; }

        public ICollection<ProductAttributeColor>? ProductAttributeColors { get; set; } // Navigation property
        public ICollection<ProductAttributeSize>? ProductAttributeSizes { get; set; } // Navigation property
    }

}
