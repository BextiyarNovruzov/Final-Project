using Gymon.BL.ViewModels.Review;
using Gymon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.ProductVMs
{
    public class ProductDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string CoverImage { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal SellPrice { get; set; }
        public List<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>(); // Initialize to avoid null references
        public List<string> Images { get; set; } = new List<string>();
        public List<Category> Categories { get; set; } = new List<Category>(); // Initialize to avoid null references
        public string UserId { get; set; }
    }

}
