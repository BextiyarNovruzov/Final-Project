using Gymon.BL.Services.Interfaces;
using Gymon.Core.Entities.ProductAttributies;
using Gymon.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gymon.MVC.Areas.Admin.Controllers
{
        [Area("Admin")]
        [Authorize(Roles = nameof(Roles.Admin))]
        public class AttributesController : Controller
        {
            private readonly IColorService _colorService;
            private readonly ISizeService _sizeService;

            public AttributesController(IColorService colorService, ISizeService sizeService)
            {
                _colorService = colorService;
                _sizeService = sizeService;
            }

            // Color Actions
            public async Task<IActionResult> Colors()
            {
                var colors = await _colorService.GetAllColorsAsync();
                return View(colors);
            }

            [HttpGet]
            public IActionResult CreateColor() => View();

            [HttpPost]
            public async Task<IActionResult> CreateColor(Color color)
            {
                if (!ModelState.IsValid)
                    return View(color);

                await _colorService.AddColorAsync(color);
                return RedirectToAction(nameof(Colors));
            }

            [HttpGet]
            public async Task<IActionResult> EditColor(int id)
            {
                var color = await _colorService.GetColorByIdAsync(id);
                return View(color);
            }

            [HttpPost]
            public async Task<IActionResult> EditColor(Color color)
            {
                if (!ModelState.IsValid)
                    return View(color);

                await _colorService.UpdateColorAsync(color);
                return RedirectToAction(nameof(Colors));
            }

            [HttpPost]
            public async Task<IActionResult> DeleteColor(int id)
            {
                await _colorService.DeleteColorAsync(id);
                return RedirectToAction(nameof(Colors));
            }

            // Size Actions
            public async Task<IActionResult> Sizes()
            {
                var sizes = await _sizeService.GetAllSizesAsync();
                return View(sizes);
            }

            [HttpGet]
            public IActionResult CreateSize() => View();

            [HttpPost]
            public async Task<IActionResult> CreateSize(Size size)
            {
                if (!ModelState.IsValid)
                    return View(size);

                await _sizeService.AddSizeAsync(size);
                return RedirectToAction(nameof(Sizes));
            }

            [HttpGet]
            public async Task<IActionResult> EditSize(int id)
            {
                var size = await _sizeService.GetSizeByIdAsync(id);
                return View(size);
            }

            [HttpPost]
            public async Task<IActionResult> EditSize(Size size)
            {
                if (!ModelState.IsValid)
                    return View(size);

                await _sizeService.UpdateSizeAsync(size);
                return RedirectToAction(nameof(Sizes));
            }   

            [HttpPost]
            public async Task<IActionResult> DeleteSize(int id)
            {
                await _sizeService.DeleteSizeAsync(id);
                return RedirectToAction(nameof(Sizes));
            }
        }

    }

