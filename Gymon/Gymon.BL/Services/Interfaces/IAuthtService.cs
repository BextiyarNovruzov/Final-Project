using Gymon.BL.ViewModels.AuthVMs;
using Gymon.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Interfaces
{
    public interface IAuthtService
    {
        Task<User> LoginAsync(LoginVM vm);
        Task RegisterAsync(RegisterVM vm);
        Task LogoutAsync();
        Task<string> GetRedirectUrlAsync(string username, string returnUrl);
    }
}
