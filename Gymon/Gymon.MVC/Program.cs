using Gymon.BL;
using Gymon.Core.Enums;
using Gymon.DAL.Context;
using Gymon.MVC.Extentions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Gymon.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Add DBcontext
            builder.Services.AddDbContext<GymonDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
            });

            builder.Services.AddAutoMapper();
            builder.Services.AddServicees();
            builder.Services.AddRepositories();




            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
     .AddCookie(options =>
     {
         options.LoginPath = "/Account/Login";
         options.LogoutPath = "/Account/Logout";
         options.AccessDeniedPath = "/Home/AccessDenied";

         options.Events.OnRedirectToLogin = context =>
         {
             // Giriş yapmamış kullanıcı için yönlendirme
             if (!context.HttpContext.User.Identity.IsAuthenticated)
             {
                 context.Response.Redirect("/Account/Login");
             }

             return Task.CompletedTask;
         };
     });



            builder.Services.AddAuthorization();
            var app = builder.Build();
            //app.UseUserSeed();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseUserSeedAsync();




            app.UseRouting();

            app.UseAuthentication();  // Authentication
            app.UseAuthorization();   // Authorization

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
