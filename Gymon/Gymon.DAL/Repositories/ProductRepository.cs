using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Gymon.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        protected readonly GymonDbContext _context;

        public ProductRepository(GymonDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
        {
            return await _context.Products
                .Include(p => p.Category) // Ürünlerle ilişkili kategorileri dahil et
                .ToListAsync(); // Asenkron olarak listeyi al
        }
        public async Task<int> GetTotalProductsCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<List<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize)
        {
            return await _context.Products
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<Product> GetProductWithImageByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Images) // Gerekli olan ilişkileri dahil edin
                                          .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Product> GetProductDetailsAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

  
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Images)    // Ensure images are included
                .Include(p => p.Reviews)    // Ensure reviews are included
                .Include(p => p.Category)  // Ensure categories are included
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public void AddReview(int productId, Review review)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                product.Reviews.Add(review); // Assuming Reviews is a collection in Product
                _context.SaveChanges();
            }
        }

        public async Task<List<Review>> GetReviewsByProductIdAsync(int productId)
        {
            return await _context.Reviews
                .Where(r => r.ProductId == productId)
                .ToListAsync();
        }
    }
}
