using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.SportTypeVMs;
using Gymon.Core.Enums;
using Gymon.Core.Repostitories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gymon.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = nameof(Roles.Admin))]


public class SportTypeController(ISportTypeService service,ISportTypeRepository repository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var sportTypes = await repository.GetAllAsync();
        return View(sportTypes);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateAndUpdateSportTypeVM vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }
        await service.CreateSportType(vm);
        return RedirectToAction("Index", "SportType");
    }
    public async Task<IActionResult> Update(int? id)
    {
        await service.UpdateSportTypeGet(id);
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Update(int? id, CreateAndUpdateSportTypeVM vm)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        await service.UpdateSportTypePost(id, vm);
        return RedirectToAction("Index", "SportType");
    }
    public async Task<IActionResult> Delete(int? id)
    {
        await service.DeleteSportType(id);
        return RedirectToAction("Index", "SportType");
    }
}
