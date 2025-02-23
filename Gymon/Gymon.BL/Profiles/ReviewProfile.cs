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
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewViewModel>()
    .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt)); // Ensure this maps correctly

        }

    }

}
