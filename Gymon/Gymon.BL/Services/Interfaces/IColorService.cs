using Gymon.Core.Entities.ProductAttributies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Interfaces
{
    public interface IColorService
    {
        Task<List<Color>> GetAllColorsAsync();
        Task<Color> GetColorByIdAsync(int id);
        Task<bool> AddColorAsync(Color color);
        Task<bool> UpdateColorAsync(Color color);
        Task<bool> DeleteColorAsync(int id);
    }
}
