using Gymon.BL.ViewModels.AppointmentVM;
using Gymon.Core.Entities;

namespace Gymon.BL.Services.Interfaces;

public interface IAppointmentService
{
    Task BookAppointment(AppointmentCreateVM model, int userId);
    Task<List<Appointment>> GetPendingAppointmentsAsync();
    Task ConfirmAppointmentAsync(int appointmentId);
    Task CancelAppointmentAsync(int appointmentId);
    Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
}
