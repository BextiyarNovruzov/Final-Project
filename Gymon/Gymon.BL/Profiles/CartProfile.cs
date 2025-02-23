using AutoMapper;
using Gymon.BL.ViewModels.Cart;
using Gymon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Product, CartItemViewModel>()
              .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id)) // Id'yi ProductId'ye eşle
              .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name)) // Name'i ProductName'e eşle
              .ForMember(dest => dest.CoverImage, opt => opt.MapFrom(src => src.CoverImage)) // CoverImage'i eşle
              .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.DiscountedPrice)); // Fiyatı indirimli fiyattan al
        }
    }
}
