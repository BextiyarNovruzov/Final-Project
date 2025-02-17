using AutoMapper;
using Gymon.BL.Exceptions.CommonExceptions;
using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.SportTypeVMs;
using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Gymon.DAL.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Imlements
{
    public class SportTypeService(ISportTypeRepository repo, IMapper mapper) : ISportTypeService
    {
        public async Task CreateSportType(CreateAndUpdateSportTypeVM vm)
        {
            var sportType = await repo.GetFirstAsync(x => x.Name == vm.Name);
            if (sportType != null)
            {
                if (sportType.Name == vm.Name)
                    throw new ExistException<User>(" Is exsit this SportType");
            }
            sportType = mapper.Map<SportType>(vm);
            await repo.AddAsync(sportType);
            await repo.SaveAsync();
        }

        public async Task DeleteSportType(int? id)
        {
            await repo.DeleteAsync(id);
            await repo.SaveAsync();
        }

        public async Task<List<SportType>> GetAllAsync()
        {
            return await repo.GetAllAsync();
        }
        public Task UpdateSportType(int? id, CreateAndUpdateSportTypeVM vm)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateSportTypeGet(int? id)
        {
            var data = await repo.GetFirstAsync(x=>x.Id == id);
            if (data == null) throw new NotFoundException<SportType>();
            CreateAndUpdateSportTypeVM vm = new CreateAndUpdateSportTypeVM
            {
                Name = data.Name,
            };
        }

        public async Task UpdateSportTypePost(int? id, CreateAndUpdateSportTypeVM vm)
        {
            if (id == null) throw new NotImplementedException();
            var data = await repo.GetFirstAsync(x => x.Id == id);
            if (data == null) throw new NotFoundException<SportType>();

            data.Name = vm.Name;
            await repo.UpdateAsync(data);
            await repo.SaveAsync();

        }
    }
}
