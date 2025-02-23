using AutoMapper;
using Gymon.BL.Services.Interfaces;
using Gymon.BL.ViewModels.ProductVMs;
using Gymon.BL.ViewModels.TrainnerVMs;
using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Gymon.DAL.Repositories;
using Microsoft.AspNetCore.Http;

namespace Gymon.BL.Services.Imlements
{
    public class ProductService(IProductRepository _productRepository, IFileService _fileService, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllWithCategoryAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
        public Product GetProductById(int productId)
        {
            return _productRepository.GetById(productId);
        }

        public async Task<bool> CreateAsync(CreateProductVM model)
        {
            if (model.CoverImageFile == null) return false;

            var product = _mapper.Map<Product>(model);

            // Set the correct upload folder for images
            string uploadsFolder = Path.Combine("wwwroot", "imgs", "products");

            // Handle the image upload
            string imageUrl = await _fileService.SaveImageAsync(model.CoverImageFile, uploadsFolder);

            // Set the image URL
            product.CoverImage = "/imgs/products/" + imageUrl;

            await _productRepository.AddAsync(product);

            return await _productRepository.SaveAsync() > 0;
        }


        public async Task<bool> UpdateAsync(UpdateProductVM model)
        {
            var product = await _productRepository.GetByIdAsync(model.Id);
            if (product == null) return false;

            // If a new cover image file is provided
            if (model.CoverImageFile != null)
            {
                // Delete the old cover image
                _fileService.DeleteFile(product.CoverImage);

                // Save the new cover image and update the product's CoverImage property
                var coverImageName = await _fileService.SaveImageAsync(model.CoverImageFile, "imgs/products");
                product.CoverImage = coverImageName; // Update to the new image path
            }

            // Map other properties from the model to the product
            _mapper.Map(model, product);

            // Update the product in the repository
            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveChangesAsync();
            return true;
        }


        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                _productRepository.Delete(product);
                await _productRepository.SaveChangesAsync();
            }
        }
        public async Task<ProductListVM> GetProductsAsync(int page)
        {
            int pageSize = 12;
            int totalProducts = await _productRepository.GetTotalProductsCountAsync();
            int totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            var products = await _productRepository.GetPaginatedProductsAsync(page, pageSize);
            var productVMs = _mapper.Map<List<ProductItemsVM>>(products);

            return new ProductListVM
            {
                Products = productVMs,
                PageNumber = page,
                TotalPages = totalPages
            };
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductWithImageByIdAsync(id); // Repositories üzerinden detayları getirin
        }


        public async Task<ProductDetailsVM> GetProductDetailsAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return null; // Veya bir hata fırlatabilirsiniz.
            }

            return _mapper.Map<ProductDetailsVM>(product);
        }


        public ProductDetailsVM GetProductDetails(int productId)
        {
            var product = _productRepository.GetProductByIdAsync(productId);
            return _mapper.Map<ProductDetailsVM>(product);
        }

        public void AddReview(int productId, Review review)
        {
            _productRepository.AddReview(productId, review);
        }
        public async Task<List<Review>> GetReviewsByProductIdAsync(int productId)
        {
            return await _productRepository.GetReviewsByProductIdAsync(productId);
        }
    }
}
