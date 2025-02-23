using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ViewModels.ProductVMs
{
    public class UpdateProductVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün adı gereklidir.")]
        [StringLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Açıklama gereklidir.")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; } = null!;

        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı 0 veya daha büyük olmalıdır.")]
        public int Stock { get; set; }

        public string? CoverImage { get; set; } // Mevcut kapak resmi

        [DataType(DataType.Upload)]
        public IFormFile? CoverImageFile { get; set; } // Yeni kapak resmi (Opsiyonel)

        [Range(0, 100, ErrorMessage = "İndirim oranı 0 ile 100 arasında olmalıdır.")]
        public decimal Discount { get; set; }

        [Required(ErrorMessage = "Maliyet fiyatı girilmelidir.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Maliyet fiyatı 0'dan büyük olmalıdır.")]
        public decimal CostPrice { get; set; }

        [Required(ErrorMessage = "Satış fiyatı girilmelidir.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Satış fiyatı 0'dan büyük olmalıdır.")]
        public decimal SellPrice { get; set; }

        [Required(ErrorMessage = "Kategori seçilmelidir.")]
        public int CategoryId { get; set; }

        public List<IFormFile>? ImageFiles { get; set; } // Yeni resimler eklenebilir
    }
}
