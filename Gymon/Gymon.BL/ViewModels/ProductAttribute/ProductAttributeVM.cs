using Gymon.Core.Entities.ProductAttributies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.ProductAttribute
{
    using System.ComponentModel.DataAnnotations;

    public class ProductAttributeVM
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        public string? Models { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        public string? Brands { get; set; }

        // For checkboxes
        public List<int>? ColorIds { get; set; } = new List<int>();
        public List<int>? SizeIds { get; set; } = new List<int>();
        public List<ColorVM>? Colors { get; set; } // ColorViewModel, renklerin özelliklerini temsil eden bir model olmalı
        public List<SizeVM>? Sizes { get; set; }

    }

}
