using Gymon.Core.Entities;

namespace Gymon.Core.Repostitories
{
    public interface IAppointmentRepository:IGenericRepository<Appointment>
    {
        Task<List<Appointment>> GetPendingAppointmentsAsync();
        Task<bool> ConfirmAppointmentAsync(int id);
        Task<bool> CancelAppointmentAsync(int id);
        Task<List<Appointment>> GetAllAppointmentsAsync();

    }
}
