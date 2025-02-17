using AutoMapper;
using Gymon.BL.ViewModels.AuthVMs;
using Gymon.BL.ViewModels.TrainnerVMs;
using Gymon.Core.Entities;
using Gymon.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Profiles
{
    public class TrainerProfile : Profile
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
              CreateMap<CreateTrainerVM, Trainer>()
             .ForMember(dest => dest.TrainerSportTypes, opt => opt.MapFrom(src => src.TrainerSportTypesId.Select(id => new TrainerSportType
             {
                 SportTypeId = id
             })));

                CreateMap<UpdateTrainerVM, Trainer>()
         .ForMember(dest => dest.TrainerSportTypes, opt => opt.MapFrom(src =>
             src.TrainerSportTypesId.Select(sportTypeId => new TrainerSportType
             {
                 TrainerId = src.Id,
                 SportTypeId = sportTypeId
             }).ToList()))
         .ForMember(dest => dest.ImageUrl, opt => opt.Condition(src => src.Image != null));

                CreateMap<Trainer, UpdateTrainerVM>()
                    .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                    .ForMember(dest => dest.TrainerSportTypesId, opt => opt.MapFrom(src =>
                        src.TrainerSportTypes.Select(tst => tst.SportTypeId).ToList()));

            }

        }


    }

}

