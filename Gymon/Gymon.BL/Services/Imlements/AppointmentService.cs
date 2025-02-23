using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.AppointmentVM;
using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using AutoMapper;
using Gymon.DAL.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;
using Gymon.Core.Enums;

namespace Gymon.BL.Services.Implements
{
    public class AppointmentService(IAppointmentRepository _appointmentRepository, ITrainerRepository _trainerRepository, ISportTypeRepository _sportTypeRepository, IMapper _mapper,IEmailService _emailService) : IAppointmentService
    {
        public async Task BookAppointment(AppointmentCreateVM model, int userId)
        {
            // AutoMapper kullanarak Appointment nesnesini oluştur
            var appointment = _mapper.Map<Appointment>(model);
            appointment.UserId = userId; // Kullanıcıyı atama
            appointment.Status = AppointmentStatus.Pending; // Durumu ayarla

            await _appointmentRepository.AddAsync(appointment);
            await _appointmentRepository.SaveAsync();
        }

        public async Task<List<Appointment>> GetPendingAppointmentsAsync()
        {
            return await _appointmentRepository.GetPendingAppointmentsAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _appointmentRepository.GetAllAppointmentsAsync();
        }
        public async Task ConfirmAppointmentAsync(int appointmentId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);

            if (appointment == null)
            {
                throw new InvalidOperationException($"No appointment found with ID: {appointmentId}");
            }

            // Update the status to Confirmed using the enum
            appointment.Status = AppointmentStatus.Confirmed;

            string message = $"Your appointment is confirmed for {appointment.AppointmentDate.ToShortDateString()} " +
                             $"{appointment.AppointmentTime}.";

            // Logic to send confirmation message...

            await _appointmentRepository.UpdateAsync(appointment); // Save changes
        }


        public async Task CancelAppointmentAsync(int appointmentId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);

            if (appointment == null)
            {
                // Handle the case where the appointment is not found
                throw new Exception("Appointment not found.");
            }

            // Proceed with canceling the appointment
            appointment.Status = AppointmentStatus.Canceled; // Update status or perform your logic

            string message = $"Your appointment for {appointment.AppointmentDate.ToShortDateString()} " +
                             $"{appointment.AppointmentTime} has been canceled.";
            // Logic to send the cancellation message...

            await _appointmentRepository.UpdateAsync(appointment); // Save changes to the database
        }

    }
}