﻿using Gymon.BL;
using Gymon.Core.Entities;
using Gymon.DAL.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Gymon.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add DbContext
            builder.Services.AddDbContext<GymonDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("MsSql"),
                sqlServerOptions =>
                {
                    sqlServerOptions.CommandTimeout(3600);
                    sqlServerOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
                }));

            builder.Services.AddDistributedMemoryCache(); // Gerekli önbelleği ekle
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddHttpContextAccessor();


            // Add AutoMapper and Custom Services
            builder.Services.AddAutoMapper();
            builder.Services.AddServices();   // Bu servislerin sıralaması genellikle önemli değil
            builder.Services.AddRepositories();
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

            // Authentication ve Authorization'ı önce ekle
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.AccessDeniedPath = "/Home/AccessDenied";

                    options.Events.OnRedirectToLogin = context =>
                    {
                        if (!context.HttpContext.User.Identity.IsAuthenticated)
                        {
                            context.Response.Redirect("/Account/Login");
                        }

                        return Task.CompletedTask;
                    };
                });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();  // Production için HSTS kullanımı
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession(); // Session middleware'ını buraya ekleyin
            app.UseRouting();

            app.UseAuthentication();  // Authentication middleware
            app.UseAuthorization();   // Authorization middleware

            // Route Configuration
            app.MapControllerRoute(
                name: "register",
                pattern: "register",
                defaults: new { controller = "Account", action = "Register" }
            );

            app.MapControllerRoute(
                name: "logout",
                pattern: "logout",
                defaults: new { controller = "Account", action = "Logout" }
            );

            app.MapControllerRoute(
                name: "login",
                pattern: "login",
                defaults: new { controller = "Account", action = "Login" }
            );

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
