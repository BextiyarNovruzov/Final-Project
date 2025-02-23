using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.CategoryVMs;
using Gymon.Core.Entities;
using Gymon.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gymon.MVC.Areas.Admin.Controllers;
    [Area("Admin")]
[Authorize(Roles =nameof(Roles.Admin))]

    public class CategoryController(ICategoryService _categoryService) : Controller
    {

        // GET: Category
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return View(categories);
        }



    public IActionResult Create()
    {
        var model = new CreateAndUpdateCategoryVM(); // Initialize the model
        return View(model); // Pass the model to the view
    }


    // POST: Category/Create
    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAndUpdateCategoryVM model)
        {
            if (ModelState.IsValid)
            {
                // Veritabanına kategori ekleme işlemi
                var category = new Category
                {
                    Name = model.Name
                };

                await _categoryService.AddCategoryAsync(category);
                return RedirectToAction(nameof(Index)); // Başarıyla oluşturulursa Index sayfasına yönlendirme
            }

            return View(model); // Model geçerli değilse aynı sayfayı tekrar göster
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var model = new CreateAndUpdateCategoryVM
            {
                Name = category.Name
            };

            return View(model);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, CreateAndUpdateCategoryVM model)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return NotFound();
                }

                category.Name = model.Name;

                await _categoryService.UpdateCategoryAsync(category);
                return RedirectToAction(nameof(Index)); // Başarıyla güncellenirse Index sayfasına yönlendirme
            }

            return View(model); // Model geçerli değilse aynı sayfayı tekrar göster
        }


        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }


