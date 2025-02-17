using AutoMapper;
using Gymon.BL.ViewModels.SportTypeVMs;
using Gymon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Profiles
{
    public class SportTypeProfile : Profile
    {
        public SportTypeProfile()
        {
            CreateMap<CreateAndUpdateSportTypeVM, SportType>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
