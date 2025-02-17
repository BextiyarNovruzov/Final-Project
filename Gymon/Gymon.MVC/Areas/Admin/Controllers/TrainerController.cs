using AutoMapper;
using Gymon.BL.Services.Imlements;
using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.TrainnerVMs;
using Gymon.Core.Entities;
using Gymon.Core.Enums;
using Gymon.Core.Repostitories;
using Gymon.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gymon.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = nameof(Roles.Admin))]


public class TrainerController(ITrainerService service,ISportTypeService sportTypeService ,IWebHostEnvironment web,ISportTypeRepository sportTyperepo,
    IMapper _mapper) : Controller
{
    public async Task<IActionResult> Index()
    {
        var trainers = await service.GetAllAsync(); // Or the appropriate method to fetch all trainers
        return View(trainers);  // Ensure the model is passed to the view
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var sportTypes = await sportTypeService.GetAllAsync();
        var model = new CreateTrainerVM
        {
            SportTypes = sportTypes.Select(st => new SelectListItem
            {
                Value = st.Id.ToString(),
                Text = st.Name
            }).ToList()
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTrainerVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            bool result = await service.CreateAsync(model);
            if (result)
            {
                TempData["SuccessMessage"] = "Trainer successfully created!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "An error occurred while saving the trainer.");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }

        return View(model);
    }


    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var trainer = await service.GetTrainerByIdAsync(id);

        if (trainer == null)
        {
            TempData["ErrorMessage"] = "Trainer not found.";
            return RedirectToAction("Index");
        }

        // Trainer'ı ViewModel'e dönüştür
        var model = _mapper.Map<UpdateTrainerVM>(trainer);

        // Eğer trainer'ın bir resmi varsa, mevcut URL'yi ViewModel'e ekleyelim
        model.ImageUrl = trainer.ImageUrl;

        // SportTypes listesini çek ve dropdown için liste oluştur
        var sportTypes = await sportTypeService.GetAllAsync();
        if (sportTypes == null)
        {
            TempData["ErrorMessage"] = "Sport types could not be loaded.";
            return RedirectToAction("Index");
        }

        model.SportTypes = sportTypes.Select(st => new SelectListItem
        {
            Value = st.Id.ToString(),
            Text = st.Name,
            Selected = trainer.TrainerSportTypes != null && trainer.TrainerSportTypes.Any(tst => tst.SportTypeId == st.Id)
        }).ToList();

        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> Update(int id, UpdateTrainerVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var trainer = await service.GetTrainerByIdAsync(id);

        if (trainer == null)
        {
            TempData["ErrorMessage"] = "Trainer not found.";
            return RedirectToAction("Index");
        }

        // Güncelleme işlemini gerçekleştir
        bool result = await service.UpdateTrainerAsync(model, model.Image);

        if (result)
        {
            TempData["SuccessMessage"] = "Trainer updated successfully!";
            return RedirectToAction("Index");
        }
        else
        {
            TempData["ErrorMessage"] = "Trainer update failed.";
            return View(model);
        }
    }   


    public async Task<IActionResult> Delete(int id)
    {
        await service.DeleteTrainerAsync(id);
        return RedirectToAction("Index"); 
    }
}
