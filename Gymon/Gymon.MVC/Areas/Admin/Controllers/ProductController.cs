using AutoMapper;
using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.ProductVMs;
using Gymon.Core.Entities;
using Gymon.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gymon.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = nameof(Roles.Admin))]

public class ProductController(IProductService _productService, ICategoryService _categoryService, IMapper _mapper,IFileService _fileService) : Controller
{
    // Tüm ürünleri listele
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllAsync();
        var productViewModels = _mapper.Map<IEnumerable<ProductsVM>>(products);
        return View(productViewModels);
    }


    // Yeni ürün ekleme formu
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Categories = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");
        return View();
    }

    // Yeni ürün ekleme işlemi
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductVM model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name");
            return View(model);
        }

        var result = await _productService.CreateAsync(model);
        if (!result) return BadRequest();

        return RedirectToAction("Index");
    }

    // Ürün Güncelleme Formu
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound();

        var model = _mapper.Map<UpdateProductVM>(product);
        ViewBag.Categories = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name", product.CategoryId);
        return View(model);
    }

    // Ürün Güncelleme İşlemi
    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductVM model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetCategoriesAsync(), "Id", "Name", model.CategoryId);
            return View(model);
        }

        var result = await _productService.UpdateAsync(model);
        if (!result) return BadRequest();

        return RedirectToAction("Index");
    }

    // Ürün Silme İşlemi
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetByIdAsync(id);
         _fileService.DeleteFile(product.CoverImage);
        await _productService.DeleteProductAsync(id);
        return RedirectToAction("Index");
    }

}
