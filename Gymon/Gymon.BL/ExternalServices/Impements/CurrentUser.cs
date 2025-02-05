using AutoMapper;
using Gymon.BL.Constant;
using Gymon.BL.Exceptions.CommonExceptions;
using Gymon.BL.ExternalServices.Interfaces;
using Gymon.BL.ViewModels.AuthVMs;
using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ExternalServices.Impements
{

    public class CurrentUser(IHttpContextAccessor _httpContext,
        IUserRepository _repo,
        IMapper _mapper) : ICurrentUser
    {
        ClaimsPrincipal? User = _httpContext.HttpContext?.User;
        public string GetEmail()
        {
            var value = User.FindFirst(x => x.Type == ClaimType.Email)?.Value;
            if (value is null)
                throw new NotFoundException<User>();
            return value;
        }

        public string GetFullname()
        {
            var value = User.FindFirst(x => x.Type == ClaimType.FullName)?.Value;
            if (value is null)
                throw new NotFoundException<User>();
            return value;
        }

        public int GetId()
        {
            var value = User.FindFirst(x => x.Type == ClaimType.Id)?.Value;
            if (value is null)
                throw new NotFoundException<User>();
            return Convert.ToInt32(value);
        }

        public int GetRole()
        {
            var value = User.FindFirst(x => x.Type == ClaimType.Role)?.Value;
            if (value is null)
                throw new NotFoundException<User>();
            return Convert.ToInt32(value);
        }

        public async Task<UserGetVM> GetUserAsync()
        {
            int userId = GetId();
            var user = await _repo.GetByIdAsync(userId);
            return _mapper.Map<UserGetVM>(user);
        }

        public string GetUserName()
        {
            var value = User.FindFirst(x => x.Type == ClaimType.Username)?.Value;
            if (value is null)
                throw new NotFoundException<User>();
            return value;
        }
    }
}
