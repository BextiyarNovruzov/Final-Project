using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Entities.ProductAttributies
{
    public class ProductAttributeSize
    {
        public int ProductAttributeId { get; set; }
        public ProductAttribute ProductAttribute { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }
    }

}
