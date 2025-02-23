using AutoMapper;
using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.ProductAttribute;
using Gymon.Core.Entities.ProductAttributies;
using Gymon.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gymon.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class ProductAttributeController(IProductAttributeService _productAttributeService, IColorService _colorService, ISizeService _sizeService, IMapper _mapper) : Controller
    {

        public async Task<IActionResult> Index(int productId)
        {
            ViewBag.ProductId = productId;
            var attributes = await _productAttributeService.GetAttributesByProductIdAsync(productId);
            var model = _mapper.Map<List<ProductAttributeVM>>(attributes);

            // Renk ve boyut verilerini yükleme
            var colors = await _colorService.GetAllColorsAsync();
            var sizes = await _sizeService.GetAllSizesAsync();

            // Renk ve boyutları her bir ProductAttributeVM'e ekleme
            foreach (var item in model)
            {
                item.Colors = colors.Select(c => new ColorVM { Id = c.Id, Name = c.Name }).ToList();
                item.Sizes = sizes.Select(s => new SizeVM { Id = s.Id, Name = s.Name }).ToList();
            }

            return View(model);
        }





        [HttpGet]
        public async Task<IActionResult> Create(int productId)
        {
            var model = new ProductAttributeVM
            {
                ProductId = productId, // ProductId formda bind edilecek
                Colors = (await _colorService.GetAllColorsAsync()).Select(c => _mapper.Map<ColorVM>(c)).ToList(),
                Sizes = (await _sizeService.GetAllSizesAsync()).Select(s => _mapper.Map<SizeVM>(s)).ToList()
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductAttributeVM model)
        {
            // Model geçerliliğini kontrol et
            if (ModelState.IsValid)
            {
                var productAttribute = _mapper.Map<ProductAttribute>(model);
                productAttribute.ProductId = model.ProductId;
                productAttribute.ProductAttributeColors = model.ColorIds.Select(colorId => new ProductAttributeColor { ColorId = colorId }).ToList();
                productAttribute.ProductAttributeSizes = model.SizeIds.Select(sizeId => new ProductAttributeSize { SizeId = sizeId }).ToList();

                // Ürün atributunu ekle
                var result = await _productAttributeService.AddAttributeAsync(productAttribute);

                // Sonuç kontrolü
                if (result)
                {
                    return RedirectToAction("Index", "ProductAttribute", new { productId = model.ProductId });
                }
                else
                {
                    ModelState.AddModelError("", "Unable to create product attribute.");
                }
            }

            // Hata durumunda renkleri ve boyutları yeniden yükle
            model.Colors = (await _colorService.GetAllColorsAsync()).Select(c => _mapper.Map<ColorVM>(c)).ToList();
            model.Sizes = (await _sizeService.GetAllSizesAsync()).Select(s => _mapper.Map<SizeVM>(s)).ToList();

            return View(model); // Form verileriyle birlikte tekrar göster
        }



            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(int id, int productId)
            {
                // Call the service to delete the attribute
                var result = await _productAttributeService.DeleteAttributeAsync(id);

                if (result)
                {
                    // Optionally add a success message here
                    return RedirectToAction("Index", new { productId });
                }
                else
                {
                    // Handle failure (e.g., add an error message)
                    ModelState.AddModelError("", "Unable to delete product attribute.");
                    return RedirectToAction("Index", new { productId });
                }
            }
        }


    }

