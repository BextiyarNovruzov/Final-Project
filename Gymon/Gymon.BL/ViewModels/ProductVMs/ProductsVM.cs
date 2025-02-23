using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.ProductVMs
{
    public class ProductsVM
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!; // Ensures that Name is never null

        public string Description { get; set; } = null!; // Ensures that Description is never null

        public int Stock { get; set; }

        public string CoverImage { get; set; } = null!; // Kapak resmi yolu

        public decimal Discount { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SellPrice { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!; // Kategori ismi

        public List<string>? Images { get; set; } // Ürüne ait ek resimler
    }

}
