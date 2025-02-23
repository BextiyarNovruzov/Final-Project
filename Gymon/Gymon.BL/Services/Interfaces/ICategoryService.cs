using Gymon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);
        Task<Category?> GetCategoryByIdAsync(int categoryId);
        Task<Category?> GetCategoryByNameAsync(string name);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoriesByConditionAsync(Expression<Func<Category, bool>> predicate);
    }
}
