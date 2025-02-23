using Gymon.Core.Entities.ProductAttributies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Interfaces
{
    public interface ISizeService
    {
        Task<List<Size>> GetAllSizesAsync();
        Task<Size> GetSizeByIdAsync(int id);
        Task<bool> AddSizeAsync(Size size);
        Task<bool> UpdateSizeAsync(Size size);
        Task<bool> DeleteSizeAsync(int id);
    }
}
