using Gymon.BL.Services.Imlements;
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
        public static IServiceCollection AddServicees(this IServiceCollection services)
        {
            services.AddScoped<IAuthtService, AuthService>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
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
