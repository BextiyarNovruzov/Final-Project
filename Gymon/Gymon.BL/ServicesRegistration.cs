using Gymon.BL.Services.Imlements;
using Gymon.BL.Services.Implements;
using Gymon.BL.Services.Interfaces;
using Gymon.Core.Repostitories;
using Gymon.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;

using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using FileService = Gymon.BL.Services.Imlements.FileService;
using ReviewService = Gymon.BL.Services.Imlements.ReviewService;
using ProductService = Gymon.BL.Services.Imlements.ProductService;
using Gymon.Core.Entities;

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
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductAttributeService, ProductAttributeService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IEmailService, EmailService>(sp =>
            {
                var emailSettings = sp.GetRequiredService<IOptions<EmailSettings>>().Value;
                return new EmailService(
                    emailSettings.SmtpServer,
                    emailSettings.SmtpPort,
                    emailSettings.SmtpUser,
                    emailSettings.SmtpPass
                );
            });

            services.AddSingleton<IStripeClient>(serviceProvider =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var secretKey = configuration["Stripe:SecretKey"];

                if (string.IsNullOrEmpty(secretKey))
                {
                    throw new InvalidOperationException("Stripe SecretKey is not configured.");
                }

                return new StripeClient(secretKey);
            });

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
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IProductAttributeRepository, ProductAttributeRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddHttpContextAccessor();
            return services;
        }
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServicesRegistration));
            return services;
        }
    }
}
