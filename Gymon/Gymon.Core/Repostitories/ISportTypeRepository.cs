using Gymon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Repostitories
{
    public interface ISportTypeRepository : IGenericRepository<SportType>
    {
        Task<IEnumerable<SportType>> GetSportTypesByIdsAsync(List<int> sportTypeIds);
 
    }
}
