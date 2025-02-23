using Gymon.Core.Entities.ProductAttributies;
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
    public class ProductAttributeRepository : GenericRepository<ProductAttribute>, IProductAttributeRepository
    {
        private readonly GymonDbContext _context;

        public ProductAttributeRepository(GymonDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ProductAttribute>> GetAttributesByProductIdAsync(int productId)
        {
            return await _context.ProductAttributes
           .Include(pa => pa.ProductAttributeColors)
               .ThenInclude(pac => pac.Color)
           .Include(pa => pa.ProductAttributeSizes)
               .ThenInclude(pas => pas.Size)
           .Where(pa => pa.ProductId == productId)
           .ToListAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var attribute = await _context.ProductAttributes.FindAsync(id);
            if (attribute == null)
            {
                return false; // Attribute not found
            }

            _context.ProductAttributes.Remove(attribute);
            return await _context.SaveChangesAsync() > 0; // Returns true if any changes were made
        }

    }
}
