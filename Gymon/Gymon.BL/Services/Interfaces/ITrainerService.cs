using Gymon.BL.ViewModels.SportTypeVMs;
using Gymon.BL.ViewModels.TrainnerVMs;
using Gymon.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Interfaces
{
    public interface ITrainerService
    {

        Task<IEnumerable<Trainer>> GetAllAsync();

       
        Task<bool> CreateAsync(CreateTrainerVM model);
        Task<Trainer> GetTrainerByIdAsync(int id);
        Task<bool> UpdateTrainerAsync(UpdateTrainerVM updateTrainerVM, IFormFile newImage);


        Task<IEnumerable<Trainer>> GetTrainersBySportTypeAsync(int sportTypeId);
        Task<List<TrainerSchedule>> GetAvailableTimes(int trainerId);

        Task<decimal> GetTrainerHourlyRate(int trainerId);
        Task DeleteTrainerAsync(int id);

    }
}
    