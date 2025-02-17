
using AutoMapper;
using Gymon.BL.ViewModels.AppointmentVM;
using Gymon.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Gymon.BL.Profiles.Mapings
{

    public class UserIdResolver : IValueResolver<AppointmentCreateVM, Appointment, int>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserIdResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int Resolve(AppointmentCreateVM source, Appointment destination, int destMember, ResolutionContext context)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }
    }

}
