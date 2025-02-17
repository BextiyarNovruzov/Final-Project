using AutoMapper;
using Gymon.BL.Profiles.Mapings;
using Gymon.BL.ViewModels.AppointmentVM;
using Gymon.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Gymon.BL.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<AppointmentCreateVM, Appointment>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom<UserIdResolver>());
        }
    }

}

