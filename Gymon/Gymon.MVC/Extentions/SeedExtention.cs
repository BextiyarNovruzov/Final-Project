using Gymon.BL.Helpers;
using Gymon.Core.Entities;
using Gymon.Core.Enums;
using Gymon.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Scripting;
using Org.BouncyCastle.Crypto.Generators;
using System;

namespace Gymon.MVC.Extentions
{
    public static class SeedExtension
    {
        public static async Task UseUserSeedAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<GymonDbContext>();

                if (!context.Users.Any(x => x.Username.ToUpper() == "ADMIN"))
                {
                    User user = new User
                    {
                        ComplateName = "Filankes Filankesov",
                        Username = "Admin",
                        Email = "Admin@gmail.com",
                        Role = Roles.Admin,
                        PasswordHash = HashHelper.HashPassword("123") // Hata düzeltildi
                    };

                    context.Users.Add(user);

                    try
                    {
                        await context.SaveChangesAsync(); // Async SaveChanges
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[ERROR] User seed failed: {ex.Message}");
                    }
                }
            }
        }
    }


}
