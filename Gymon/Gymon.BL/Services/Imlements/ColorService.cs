using Gymon.BL.Services.Interfaces;
using Gymon.Core.Entities.ProductAttributies;
using Gymon.Core.Repostitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Imlements;


public class ColorService : IColorService
{
    private readonly IColorRepository _colorRepository;

    public ColorService(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }

    public async Task<List<Color>> GetAllColorsAsync() => await _colorRepository.GetAllAsync();
    public async Task<Color> GetColorByIdAsync(int id) => await _colorRepository.GetByIdAsync(id);
    public async Task<bool> AddColorAsync(Color color)
    {
        await _colorRepository.AddAsync(color);
        return await _colorRepository.SaveAsync() > 0;
    }

    public async Task<bool> UpdateColorAsync(Color color)
    {
        await _colorRepository.UpdateAsync(color);
        return await _colorRepository.SaveAsync() > 0;
    }

    public async Task<bool> DeleteColorAsync(int id)
    {
        return await _colorRepository.DeleteAsync(id);
    }
}
