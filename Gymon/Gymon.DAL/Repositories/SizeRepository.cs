using Gymon.Core.Entities.ProductAttributies;
using Gymon.Core.Repostitories;
using Gymon.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Repositories
{
    public class SizeRepository : GenericRepository<Size>, ISizeRepository
    {
        public SizeRepository(GymonDbContext context) : base(context) { }
    }
}
