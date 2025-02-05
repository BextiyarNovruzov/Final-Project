using AutoMapper;
using Gymon.BL.Constant;
using Gymon.BL.Exceptions.CommonExceptions;
using Gymon.BL.Helpers;
using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.AuthVMs;
using Gymon.Core.Entities;
using Gymon.Core.Enums;
using Gymon.Core.Repostitories;
using Gymon.DAL.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace Gymon.BL.Services.Imlements;
public class AuthService(IUserRepository repo, IMapper mapper,IHttpContextAccessor httpContextAccessor) : IAuthtService
{

    public async Task RegisterAsync(RegisterVM vm)
    {
        var user = await repo.GetFirstAsync(x => x.Email == vm.Email || x.Username == vm.Username);
        if (user != null)
        {
            if (user.Email == vm.Email)
                throw new ExistException<User>("Email already using by another user");
            else if (user.Username == vm.Username)
                throw new ExistException<User>("Username already using by another user");
        }
        user = mapper.Map<User>(vm);
        await repo.AddAsync(user);
        await repo.SaveAsync();
    }


    public async Task<User> LoginAsync(LoginVM vm)
    {
        User? user = null;
        if (vm.UserNameOrEmail.Contains('@'))
        {
            user = await repo.GetFirstAsync(x => x.Email == vm.UserNameOrEmail);
        }
        else
        {
            user = await repo.GetFirstAsync(x => x.Username == vm.UserNameOrEmail);
        }
        if (user == null)
            throw new NotFoundException<User>();
        if (!HashHelper.VerifyHashedPassword(user.PasswordHash, vm.Password))
            throw new NotFoundException<User>();

        // Kullanıcının rolünü claim olarak ekliyoruz
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Username),  // Kullanıcının adını ekleyin
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),  // Kullanıcı id'sini ekleyin
        new Claim(ClaimTypes.Role, user.Role.ToString()) // Kullanıcının rolünü doğru şekilde ekliyoruz
    };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true, // Tarayıcı kapansa bile girişin hatırlanması için
            ExpiresUtc = DateTime.UtcNow.AddMinutes(1) // 1 saat geçerli olacak
        };

        await httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

        return user;
    }

    public async Task LogoutAsync()
    {
        await httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }


    public async Task<string> GetRedirectUrlAsync(string username, string returnUrl)
    {
        var user = await repo.GetUserByUsernameAsync(username);
        if (user == null)
        {
            return "/Home/Index"; // Kullanıcı yoksa ana sayfaya yönlendir
        }

        if (string.IsNullOrEmpty(returnUrl))
        {
            return user.Role == Roles.Admin ? "/Admin/Dashboard/Index" : "/Home/Index";
        }

        return returnUrl;
    }
}