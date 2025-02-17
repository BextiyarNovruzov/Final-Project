using Gymon.BL.ViewModels.SportTypeVMs;
using Gymon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Interfaces
{
    public interface ISportTypeService
    {

        Task CreateSportType(CreateAndUpdateSportTypeVM vm);
        Task UpdateSportTypePost(int? id, CreateAndUpdateSportTypeVM vm);
        Task UpdateSportTypeGet(int? id);
        Task DeleteSportType(int? id);
        Task<List<SportType>> GetAllAsync();
    }
}