using Gymon.BL.Services.Interfaces;
using Gymon.Core.Entities.ProductAttributies;
using Gymon.Core.Repostitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Imlements
{
    public class ProductAttributeService : IProductAttributeService
    {
        private readonly IProductAttributeRepository _productAttributeRepository;

        public ProductAttributeService(IProductAttributeRepository productAttributeRepository)
        {
            _productAttributeRepository = productAttributeRepository;
        }

        public async Task<List<ProductAttribute>> GetAttributesByProductIdAsync(int productId)
        {
            return await _productAttributeRepository.GetAttributesByProductIdAsync(productId);
        }

        public async Task<bool> AddAttributeAsync(ProductAttribute attribute)
        {
            if (attribute == null) throw new ArgumentNullException(nameof(attribute));

            await _productAttributeRepository.AddAsync(attribute);

            return await _productAttributeRepository.SaveAsync() > 0;
        }


        public async Task<bool> UpdateAttributeAsync(ProductAttribute attribute)
        {
            await _productAttributeRepository.UpdateAsync(attribute);
            return await _productAttributeRepository.SaveAsync() > 0;
        }

        public async Task<bool> DeleteAttributeAsync(int id)
        {
            return await _productAttributeRepository.DeleteAsync(id);
        }
    }
    }
