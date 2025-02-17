using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.AppointmentVM;
using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using AutoMapper;
using Gymon.DAL.Repositories;

namespace Gymon.BL.Services.Implements
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SportType>> GetAllSportTypesAsync()
        {
            return await _unitOfWork.SportTypes.GetAllAsync();
        }

        public async Task<IEnumerable<Trainer>> GetAllTrainersAsync()
        {
            return await _unitOfWork.Trainers.GetAllAsync();
        }

        public async Task<List<Trainer>> GetTrainersBySportTypeAsync(int sportTypeId)
        {
            var trainers = await _unitOfWork.Trainers.FindAsync(t => t.TrainerSportTypes.Any(ts => ts.SportTypeId == sportTypeId));
            return trainers.ToList();
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _unitOfWork.Appointments.GetByIdAsync(id);
        }

        public async Task CreateAppointmentAsync(AppointmentCreateVM model)
        {
            if (model.AppointmentDate.Date < DateTime.UtcNow.Date)
            {
                throw new ArgumentException("Geçmiş tarihler için randevu oluşturulamaz.");
            }

            var user = await _unitOfWork.User.GetByIdAsync(model.UserId);
            var trainer = await _unitOfWork.Trainers.GetByIdAsync(model.TrainerId);
            var sportType = await _unitOfWork.SportTypes.GetByIdAsync(model.SportTypeId);

            if (user == null || trainer == null || sportType == null)
            {
                throw new ArgumentException("User, Trainer veya SportType bulunamadı.");
            }

            var existingAppointment = await _unitOfWork.Appointments.FindAsync(a =>
                a.UserId == model.UserId && a.AppointmentDate.Date == model.AppointmentDate.Date);
            if (existingAppointment.Any())
            {
                throw new InvalidOperationException("Bu tarihte zaten bir randevunuz bulunuyor.");
            }

            var availableSchedule = await _unitOfWork.TrainerSchedules.FindAsync(s =>
                s.TrainerId == model.TrainerId &&
                s.AvailableDate.Date == model.AppointmentDate.Date &&
                s.StartTime <= model.AppointmentTime &&
                s.EndTime > model.AppointmentTime &&
                !s.IsBooked);

            if (!availableSchedule.Any())
            {
                throw new InvalidOperationException("Seçilen saat için eğitmen müsait değil.");
            }

            var appointment = _mapper.Map<Appointment>(model);
            appointment.Email = user.Email;
            appointment.FullName = user.ComplateName;
            appointment.Amount = trainer.HourlyRate * sportType.PriceMultiplier;
            appointment.PaymentStatus = false;
            appointment.Status = "Pending";

            await _unitOfWork.Appointments.AddAsync(appointment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAppointmentAsync(AppointmentCreateVM model)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(model.Id);
            if (appointment == null) throw new ArgumentException("Randevu bulunamadı.");

            _mapper.Map(model, appointment);

            await _unitOfWork.Appointments.UpdateAsync(appointment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            await _unitOfWork.Appointments.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<SportType>> GetAllSportTypeAsync()
        {
            return await _unitOfWork.SportTypes.GetAllAsync();
        }
    }
}
