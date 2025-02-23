using Gymon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.ProductVMs
{
   public  class ProductAtributeVM
    {
        public int Id { get; set; } // Unique identifier for the product
        public string Name { get; set; } // Name of the product
        public string Description { get; set; } // Description of the product
        public decimal Price { get; set; } // Price of the product
        public string CoverImage { get; set; } // URL or path to the product's cover image


    }
}
