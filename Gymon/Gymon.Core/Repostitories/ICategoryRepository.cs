using Gymon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Repostitories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<Category?> GetCategoryByNameAsync(string name);
        Task<IEnumerable<Category>> GetCategoriesByConditionAsync(Expression<Func<Category, bool>> predicate);
    }
}
