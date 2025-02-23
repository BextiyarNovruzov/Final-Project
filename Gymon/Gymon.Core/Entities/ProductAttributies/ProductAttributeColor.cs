using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Entities.ProductAttributies
{
    public class ProductAttributeColor
    {
        public int ProductAttributeId { get; set; }
        public ProductAttribute ProductAttribute { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }
    }

}
