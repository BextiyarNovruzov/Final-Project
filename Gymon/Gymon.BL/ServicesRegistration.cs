using Gymon.BL.Services.Imlements;
using Gymon.BL.Services.Implements;
using Gymon.BL.Services.Interfaces;
using Gymon.Core.Repostitories;
using Gymon.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthtService, AuthService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<ISportTypeService, SportTypeService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<ITrainerScheduleService, TrainerScheduleService>();
            services.AddScoped<IFileService, FileService>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAppointmentRepository, AppointmetRepository>();
            services.AddScoped<ITrainerRepository,TrainerRepository>();
            services.AddScoped<ISportTypeRepository, SportTypeRepository>();
            services.AddScoped<ITrainerScheduleRepository, TrainerScheduleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServicesRegistration));
            return services;
        }
    }
}
