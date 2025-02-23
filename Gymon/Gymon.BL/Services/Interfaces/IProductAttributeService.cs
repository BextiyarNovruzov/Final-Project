using Gymon.Core.Entities.ProductAttributies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Interfaces
{
    public interface IProductAttributeService
    {
        Task<List<ProductAttribute>> GetAttributesByProductIdAsync(int productId);
        Task<bool> AddAttributeAsync(ProductAttribute attribute);
        Task<bool> UpdateAttributeAsync(ProductAttribute attribute);
        Task<bool> DeleteAttributeAsync(int id);
    }
}
