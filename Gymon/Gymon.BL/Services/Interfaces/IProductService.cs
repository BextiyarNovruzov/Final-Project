using Gymon.BL.ViewModels.ProductVMs;
using Gymon.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Gymon.BL.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Product GetProductById(int productId);
        Task<bool> CreateAsync(CreateProductVM model);
        Task<bool> UpdateAsync(UpdateProductVM model);
        Task DeleteProductAsync(int id);
        Task<ProductListVM> GetProductsAsync(int page);
        Task<Product> GetProductByIdAsync(int id);
        Task<ProductDetailsVM> GetProductDetailsAsync(int id);
        ProductDetailsVM GetProductDetails(int productId);
        void AddReview(int productId, Review review);
        Task<List<Review>> GetReviewsByProductIdAsync(int productId);


    }

}
