using Gymon.BL.ViewModels.AppointmentVM;
using Gymon.Core.Entities;

namespace Gymon.BL.Services.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<SportType>> GetAllSportTypeAsync();
    Task<IEnumerable<Trainer>> GetAllTrainersAsync();
    Task CreateAppointmentAsync(AppointmentCreateVM model);
    Task UpdateAppointmentAsync(AppointmentCreateVM model);
    Task<Appointment> GetAppointmentById(int id);
    Task DeleteAppointmentAsync(int id);
    Task<List<Trainer>> GetTrainersBySportTypeAsync(int sportTypeId);
}
    