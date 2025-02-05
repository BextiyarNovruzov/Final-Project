using Gymon.BL.ViewModels.AuthVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.ExternalServices.Interfaces
{
    public interface ICurrentUser
    {
        int GetId();
        string GetUserName();
        string GetEmail();
        string GetFullname();
        int GetRole();
        Task<UserGetVM> GetUserAsync();
    }
}
