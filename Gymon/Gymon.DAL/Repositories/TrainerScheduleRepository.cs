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
    public class TrainerScheduleRepository : GenericRepository<TrainerSchedule>, ITrainerScheduleRepository
    {
        private readonly GymonDbContext _context;

        public TrainerScheduleRepository(GymonDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<TrainerSchedule>> GetAvailableTimesByTrainerIdAsync(int trainerId)
        {
            // Eğitmenin müsait olduğu saatleri filtreleyerek alıyoruz
            var availableTimes = await _context.TrainerSchedule
                .Where(ts => ts.TrainerId == trainerId && ts.IsBooked)
                .ToListAsync();

            return availableTimes;
        }

    }
}
