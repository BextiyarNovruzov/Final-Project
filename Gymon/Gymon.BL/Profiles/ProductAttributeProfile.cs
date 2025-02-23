using AutoMapper;
using Gymon.BL.ViewModels.ProductAttribute;
using Gymon.Core.Entities.ProductAttributies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Profiles
{
    public class ProductAttributeProfile : Profile
    {
        public ProductAttributeProfile()
        {
            CreateMap<ProductAttribute, ProductAttributeVM>()
    .ForMember(dest => dest.ColorIds, opt => opt.MapFrom(src =>
        src.ProductAttributeColors.Select(x => x.ColorId).ToList()))
    .ForMember(dest => dest.SizeIds, opt => opt.MapFrom(src =>
        src.ProductAttributeSizes.Select(x => x.SizeId).ToList()))
    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));


            CreateMap<ProductAttributeVM, ProductAttribute>()
                .ForMember(dest => dest.ProductAttributeColors, opt => opt.MapFrom(src =>
                    src.ColorIds.Select(colorId => new ProductAttributeColor { ColorId = colorId })))
                .ForMember(dest => dest.ProductAttributeSizes, opt => opt.MapFrom(src =>
                    src.SizeIds.Select(sizeId => new ProductAttributeSize { SizeId = sizeId })));
            // Size ile SizeVM arasında dönüşüm
            CreateMap<Size, SizeVM>();

            // Color ile ColorVM arasında dönüşüm
            CreateMap<Color, ColorVM>();
        }
    }

}
