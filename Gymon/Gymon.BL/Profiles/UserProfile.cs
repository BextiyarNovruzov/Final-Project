using AutoMapper;
using Gymon.BL.Helpers;
using Gymon.BL.ViewModels.AuthVMs;
using Gymon.Core.Entities;
using Gymon.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterVM, User>()
            .ForMember(x => x.PasswordHash, x => x.MapFrom(y => HashHelper.HashPassword(y.Password)))
             .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Roles.User));

    }

        //CreateMap<RegisterVM, User>()
        //    .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // 📌 Şifre hash'lenmeli, otomatik map edilmesin
        //    .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Roles.User)); // 📌 Varsayılan rol User olacak


}
