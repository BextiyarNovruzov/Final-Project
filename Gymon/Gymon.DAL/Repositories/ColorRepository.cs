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
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(GymonDbContext context) : base(context) { }
    }
}
