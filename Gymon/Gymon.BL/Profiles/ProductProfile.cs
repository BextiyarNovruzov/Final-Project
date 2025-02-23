using AutoMapper;
using Gymon.BL.ViewModels.ProductVMs;
using Gymon.BL.ViewModels.Review;
using Gymon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductsVM>()
      .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
      .ForMember(dest => dest.CoverImage, opt => opt.MapFrom(src => src.CoverImage)); // Burayı kontrol edin

            CreateMap<CreateProductVM, Product>();
            CreateMap<UpdateProductVM, Product>().ReverseMap();

            CreateMap<Product, ProductItemsVM>()
           .ForMember(dest => dest.CoverImage, opt => opt.MapFrom(src => src.CoverImage))
           .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src => src.SellPrice - (src.SellPrice * (src.Discount / 100)))); // İndirimli fiyat

            CreateMap<List<ProductItemsVM>, ProductListVM>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.TotalPages, opt => opt.Ignore()) // Hesaplama, controller’da yapılacak
                .ForMember(dest => dest.PageNumber, opt => opt.Ignore());

            CreateMap<Product, ProductDetailsVM>()
      .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))
      .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
      .ForMember(dest => dest.Categories, opt => opt.MapFrom(src =>
          src.Category != null ? new List<Category> { src.Category } : new List<Category>())); // Ensure Product is included

        }
    }
}