using Gymon.BL.Services.Interfaces;
using Gymon.Core.Entities;
using Gymon.Core.Repostitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Imlements
{
    public class CategoryService(ICategoryRepository _categoryRepository):ICategoryService
    {
        public async Task AddCategoryAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category != null)
            {
                _categoryRepository.Delete(category);
                await _categoryRepository.SaveChangesAsync();
            }
        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            return await _categoryRepository.GetByIdAsync(categoryId);
        }

        public async Task<Category?> GetCategoryByNameAsync(string name)
        {
            return await _categoryRepository.GetCategoryByNameAsync(name);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesByConditionAsync(Expression<Func<Category, bool>> predicate)
        {
            return await _categoryRepository.GetCategoriesByConditionAsync(predicate);
        }
    }

}
