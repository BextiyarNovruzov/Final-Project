using Gymon.Core.Entities;

namespace Gymon.Core.Repostitories
{
    public interface IAppointmentRepository:IGenericRepository<Appointment>
    {
        Task CreateAsync(Appointment appointment);
        Task<bool> IsDuplicateAppointmentAsync(int userId, DateTime appointmentDate, TimeSpan appointmentTime);

    }
}
