using Gymon.BL.Services.Imlements;
using Gymon.BL.Services.Implements;
using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.AppointmentVM;
using Gymon.Core.Entities;
using Gymon.Core.Enums;
using Gymon.Core.Repostitories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gymon.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles =nameof(Roles.Admin))]
public class AppointmentForAdminController(IAppointmentService _appointmentService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var appointments = await _appointmentService.GetAllAppointmentsAsync();
        var model = appointments.Select(a => new AppointmentListVM
        {
            Id = a.Id,
            TrainerName = a.Trainer.FullName,
            SportType = a.SportType.Name,
            AppointmentDate = a.AppointmentDate,
            AppointmentTime = a.AppointmentTime,
            Status = a.Status.ToString() // Ensure Status is converted to string
        }).ToList();

        return View(model);
    }
    

    // Randevuyu onayla
    [HttpPost]
    public async Task<IActionResult> Confirm(int id)
    {
        await _appointmentService.ConfirmAppointmentAsync(id);
        return RedirectToAction("Index");
    }

    // Randevuyu iptal et
    [HttpPost]
    public async Task<IActionResult> Cancel(int id)
    {
        await _appointmentService.CancelAppointmentAsync(id);
        return RedirectToAction("Index");
    }
}
