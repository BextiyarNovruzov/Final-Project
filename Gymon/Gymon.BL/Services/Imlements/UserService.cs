using Gymon.BL.Services.Interfaces;
using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Imlements
{
    public class UserService(IUserRepository _userRepository) : IUserService
    {
        // Kullanıcıyı UserId ile al
        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }
    }
}
