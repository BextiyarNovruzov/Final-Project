using Microsoft.AspNetCore.Http;
namespace Gymon.BL.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(IFormFile file, string folderPath);
        void DeleteFile(string filePath);

    }
}
