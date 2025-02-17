using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Repostitories
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments { get; }
        IUserRepository User { get; }
        ITrainerRepository Trainers { get; }
        ISportTypeRepository SportTypes { get; }
        ITrainerScheduleRepository TrainerSchedules { get; }
        Task<int> CompleteAsync();  // Save changes methodu
    }

}
