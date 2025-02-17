using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Gymon.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Repositories
{
    public class SportTypeRepository : GenericRepository<SportType>, ISportTypeRepository
    {
        protected readonly GymonDbContext _context;
        public SportTypeRepository(GymonDbContext context) : base(context)
        { 
            _context = context;
        }

        public async Task<IEnumerable<SportType>> GetSportTypesByIdsAsync(List<int> sportTypeIds)
        {
            return await _context.SportTypes
                    .Where(st => sportTypeIds.Contains(st.Id))
                    .ToListAsync();
        }
    }
}
