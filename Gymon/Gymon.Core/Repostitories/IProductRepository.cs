using Gymon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Repostitories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithCategoryAsync();
        Task<int> GetTotalProductsCountAsync();
        Task<List<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize);
        Task<Product> GetProductWithImageByIdAsync(int id);
        Task<Product> GetProductDetailsAsync(int id);
        Task<Product> GetProductByIdAsync(int id);
        void AddReview(int productId, Review review); // Method to add reviews
        Task<List<Review>> GetReviewsByProductIdAsync(int productId);

    }
}
