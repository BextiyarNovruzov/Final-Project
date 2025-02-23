using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using Gymon.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Repositories
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        protected readonly GymonDbContext _context;

        public CategoryRepository(GymonDbContext context) : base(context)
        {
            _context = context;
        }
        // Category adını istifadə edərək Category tapmaq
        public async Task<Category?> GetCategoryByNameAsync(string name)
        {
            return await _context.Categories
                                 .FirstOrDefaultAsync(c => c.Name == name);
        }

        // Müəyyən bir şərtə uyğun olan kateqoriyaları tapmaq
        public async Task<IEnumerable<Category>> GetCategoriesByConditionAsync(Expression<Func<Category, bool>> predicate)
        {
            return await _context.Categories
                                 .Where(predicate)
                                 .ToListAsync();
        }
    }
}
