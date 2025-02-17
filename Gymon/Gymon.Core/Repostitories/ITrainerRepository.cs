using Gymon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Repostitories
{
    public interface ITrainerRepository : IGenericRepository<Trainer>
    {
        Task<IEnumerable<Trainer>> GetAllAsync();
        Task<List<Trainer>> GetTrainersBySportTypeAsync(int sportTypeId);
    }
}
