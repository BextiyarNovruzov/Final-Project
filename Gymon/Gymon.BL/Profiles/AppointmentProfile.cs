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
            .ForMember(dest => dest.UserId, opt => opt.Ignore()) // UserId, Controller'da atanacak
            .ForMember(dest => dest.Trainer, opt => opt.Ignore()) // İlişkiyi Controller'da çöz
            .ForMember(dest => dest.SportType, opt => opt.Ignore()); 
        }
    }

}

