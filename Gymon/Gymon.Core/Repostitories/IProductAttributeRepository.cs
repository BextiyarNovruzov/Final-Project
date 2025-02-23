using Gymon.Core.Entities.ProductAttributies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Repostitories
{
    public interface IProductAttributeRepository : IGenericRepository<ProductAttribute>
    {
        Task<List<ProductAttribute>> GetAttributesByProductIdAsync(int productId);
        Task<bool> DeleteAsync(int id);
    }
}
