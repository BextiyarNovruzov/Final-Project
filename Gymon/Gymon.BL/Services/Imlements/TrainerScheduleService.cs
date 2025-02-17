using Gymon.BL.Services.Interfaces;
using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Gymon.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Imlements
{
    public class TrainerScheduleService(ITrainerRepository _trainerRepository, ITrainerScheduleRepository _trainerScheduleRepository) : ITrainerScheduleService
    {
        public async Task<List<TrainerSchedule>> GetAvailableTimes(int trainerId)
        {
            var trainer = await _trainerRepository.GetByIdAsync(trainerId);
            if (trainer == null)
            {
                throw new ArgumentException("Trainer not found.");
            }

            // Eğitmenin müsait olduğu saatleri TrainerScheduleRepository üzerinden al
            var availableTimes = await _trainerScheduleRepository.GetAvailableTimesByTrainerIdAsync(trainerId);

            return availableTimes;
        }
    }
}

