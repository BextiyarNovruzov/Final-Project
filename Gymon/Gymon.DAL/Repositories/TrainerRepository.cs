using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Gymon.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Gymon.DAL.Repositories
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        protected readonly GymonDbContext _context;

        public TrainerRepository(GymonDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trainer>> GetAllAsync()
        {
            var trainers = await _context.Trainers
                .Include(t => t.TrainerSportTypes)  // Include the TrainerSportTypes collection
                .ThenInclude(ts => ts.SportType)    // Include the SportType related to each TrainerSportType
                .ToListAsync();

            return trainers ?? new List<Trainer>();  // Return an empty list if null
        }


        public async Task<Trainer> GetByIdAsync(int id)
        {
            return await _context.Trainers
                .Include(t => t.TrainerSportTypes)
                .ThenInclude(ts => ts.SportType)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(Trainer trainer)
        {
            _context.Trainers.Update(trainer);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Trainer>> GetTrainersBySportTypeAsync(int sportTypeId)
        {
            return await _context.Trainers
                .Where(t => t.TrainerSportTypes.Any(st => st.Id == sportTypeId))
                .Include(t => t.Schedules)  // Eğitmenlerin çalışma saatlerini getir
                .ToListAsync();
        }

    }

}
