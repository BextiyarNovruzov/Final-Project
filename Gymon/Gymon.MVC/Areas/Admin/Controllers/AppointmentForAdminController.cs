using Gymon.BL.Services.Imlements;
using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.AppointmentVM;
using Gymon.Core.Enums;
using Gymon.Core.Repostitories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gymon.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles =nameof(Roles.Admin))]
public class AppointmentForAdminController(IAppointmentService service) : Controller
{
    //[HttpGet]
    //public async Task<IActionResult> ConfirmAppointment(int id)
    //{
    //    var appointment = await _appointmentService.GetByIdAsync(id);
    //    if (appointment == null) return NotFound();

    //    var trainers = await _trainerService.GetAllAsync(); // Eğitmenleri çek

    //    var model = new ConfirmAppointmentVM
    //    {
    //        AppointmentId = appointment.Id,
    //        FullName = appointment.FullName,
    //        Email = appointment.Email,
    //        Phone = appointment.Phone,
    //        SportType = appointment.SportType,
    //        AvailableTrainers = trainers
    //    };

    //    return View(model);
    //}
}
