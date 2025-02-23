using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.ProductVMs
{
    public class ProductListVM
    {
        public List<ProductItemsVM> Products { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
    }

}
