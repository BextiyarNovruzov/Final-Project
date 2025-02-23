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
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;

        public SizeService(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<List<Size>> GetAllSizesAsync() => await _sizeRepository.GetAllAsync();
        public async Task<Size> GetSizeByIdAsync(int id) => await _sizeRepository.GetByIdAsync(id);
        public async Task<bool> AddSizeAsync(Size size)
        {
            await _sizeRepository.AddAsync(size);
            return await _sizeRepository.SaveAsync() > 0;
        }

        public async Task<bool> UpdateSizeAsync(Size size)
        {
            await _sizeRepository.UpdateAsync(size);
            return await _sizeRepository.SaveAsync() > 0;
        }

        public async Task<bool> DeleteSizeAsync(int id)
        {
            return await _sizeRepository.DeleteAsync(id);
        }
    }
}
