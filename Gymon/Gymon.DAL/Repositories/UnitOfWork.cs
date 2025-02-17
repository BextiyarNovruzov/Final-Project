using Gymon.Core.Repostitories;
using Gymon.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GymonDbContext _context;
        private IUserRepository _userRepository;
        public UnitOfWork(GymonDbContext context)
        {
            _context = context;
            Appointments = new AppointmetRepository(_context);
            Trainers = new TrainerRepository(_context);
            SportTypes = new SportTypeRepository(_context);
            TrainerSchedules = new TrainerScheduleRepository(_context);
        }

        public IAppointmentRepository Appointments { get; private set; }
        public ITrainerRepository Trainers { get; private set; }
        public ISportTypeRepository SportTypes { get; private set; }
        public ITrainerScheduleRepository TrainerSchedules { get; private set; }

        public IUserRepository User => _userRepository ??= new UserRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
