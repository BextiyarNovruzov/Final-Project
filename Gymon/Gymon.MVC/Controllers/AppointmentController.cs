using Gymon.BL.Services.Implements;
using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.AppointmentVM;
using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Gymon.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace Gymon.MVC.Controllers
{
    public class AppointmentController(IAppointmentService appointmentService,ISportTypeService _sportTypeService,ITrainerService _trainerService) : Controller

    {

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> BookAppointment()
        {
            var model = new AppointmentCreateVM
            {
                SportTypes = await _sportTypeService.GetAllAsync() ?? new List<SportType>(),
                Trainers = await _trainerService.GetAllAsync() ?? new List<Trainer>()
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> BookAppointment(AppointmentCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                model.SportTypes = await _sportTypeService.GetAllAsync() ?? new List<SportType>();
                model.Trainers = await _trainerService.GetAllAsync() ?? new List<Trainer>();
            }

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await appointmentService.BookAppointment(model, userId);

            return RedirectToAction("Success");
        }






        public IActionResult Success()
        {
            return View();
        }
    }

}