using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Gymon.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(GymonDbContext context) : base(context)
        {
        }
    }
}
