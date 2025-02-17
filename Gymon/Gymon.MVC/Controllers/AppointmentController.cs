using Gymon.BL.ViewModels.AppointmentVM;
using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Microsoft.AspNetCore.Mvc;


namespace Gymon.MVC.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get Trainers by Sport Type
        [HttpGet]
        public async Task<IActionResult> GetTrainersBySportType(int sportTypeId)
        {
            if (sportTypeId == 0)
            {
                return Json(new { }); // Invalid ID case, return empty JSON
            }

            // Trainers filtered by SportTypeId
            var trainers = await _unitOfWork.Trainers
                .FindAsync(t => t.TrainerSportTypes.Any(ts => ts.SportTypeId == sportTypeId));

            if (trainers == null || !trainers.Any())
            {
                return Json(new { }); // No trainers found
            }

            // Only return the trainer id and full name
            var trainerList = trainers.Select(t => new { id = t.Id, fullName = t.FullName }).ToList();
            return Json(trainerList); // Return the list of trainers
        }

        // Get Available Schedules for the selected Trainer and Date
        [HttpGet]
        public async Task<IActionResult> GetAvailableSchedules(int trainerId, DateTime date)
        {
            if (date.Date < DateTime.UtcNow.Date)
            {
                return BadRequest("Cannot create an appointment for a past date.");
            }

            var trainer = await _unitOfWork.Trainers.GetByIdAsync(trainerId);
            if (trainer == null)
            {
                return NotFound("Trainer not found.");
            }

            // Get available schedules for the selected trainer and date
            var schedules = await _unitOfWork.TrainerSchedules
                .FindAsync(s => s.TrainerId == trainerId && s.AvailableDate.Date == date.Date && !s.IsBooked);

            if (!schedules.Any())
            {
                return NotFound("No available time slots found for the selected trainer.");
            }

            // Return available schedules (start and end times)
            var scheduleList = schedules.Select(s => new { s.StartTime, s.EndTime }).ToList();
            return Json(scheduleList);
        }

        // Show Book Appointment Form
        [HttpGet]
        public async Task<IActionResult> BookAppointment()
        {
            var viewModel = new AppointmentCreateVM
            {
                SportTypes = await _unitOfWork.SportTypes.GetAllAsync()
            };

            return View(viewModel);
        }

        // Handle Book Appointment form submission
        [HttpPost]
        public async Task<IActionResult> BookAppointment(AppointmentCreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Validate user, trainer, and sport type
            var user = await _unitOfWork.User.GetByIdAsync(model.UserId);
            var trainer = await _unitOfWork.Trainers.GetByIdAsync(model.TrainerId);
            var sportType = await _unitOfWork.SportTypes.GetByIdAsync(model.SportTypeId);

            if (user == null || trainer == null || sportType == null)
            {
                ModelState.AddModelError("", "Invalid user, trainer, or sport type selected.");
                return View(model);
            }

            // Check if the user already has an appointment for the same day
            var existingAppointment = await _unitOfWork.Appointments.FindAsync(a =>
                a.UserId == model.UserId && a.AppointmentDate.Date == model.AppointmentDate.Date);

            if (existingAppointment.Any())
            {
                ModelState.AddModelError("", "You already have an appointment for this date.");
                return View(model);
            }

            // Check if the trainer is available for the selected time
            var availableSchedules = await _unitOfWork.TrainerSchedules
                .FindAsync(s =>
                    s.TrainerId == model.TrainerId &&
                    s.AvailableDate.Date == model.AppointmentDate.Date &&
                    s.StartTime <= model.AppointmentTime &&
                    s.EndTime > model.AppointmentTime &&
                    !s.IsBooked);

            if (!availableSchedules.Any())
            {
                ModelState.AddModelError("", "Trainer is not available at the selected time.");
                return View(model);
            }

            // Calculate the amount based on Trainer's HourlyRate
            var trainerSchedule = availableSchedules.FirstOrDefault();
            if (trainerSchedule == null)
            {
                ModelState.AddModelError("", "Invalid time slot.");
                return View(model);
            }

            var amountToPay = trainer.HourlyRate; // Assuming the payment is based on the hourly rate.

            // Create new appointment
            var appointment = new Appointment
            {
                UserId = model.UserId,
                TrainerId = model.TrainerId,
                SportTypeId = model.SportTypeId,
                AppointmentDate = model.AppointmentDate,
                AppointmentTime = model.AppointmentTime,
                PaymentMethod = model.PaymentMethod,
                Notes = model.Notes,
                Email = user.Email,
                FullName = user.ComplateName,
                Phone = model.Phone,
                Amount = amountToPay,
                PaymentStatus = false, // Payment status is pending by default
                Status = "Pending"
            };

            // Save the appointment
            await _unitOfWork.Appointments.AddAsync(appointment);
            await _unitOfWork.CompleteAsync();

            return RedirectToAction("AppointmentConfirmation", new { appointmentId = appointment.Id });
        }

        // Appointment Confirmation
        public async Task<IActionResult> AppointmentConfirmation(int appointmentId)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(appointmentId);
            if (appointment == null)
            {
                return NotFound("Appointment not found.");
            }

            return View(appointment); // Show appointment details after booking
        }
    }
}