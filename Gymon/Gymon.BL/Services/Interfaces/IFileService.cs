using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(IFormFile file, string folderPath);
        Task<string> UploadFileAsync(IFormFile file);
        void DeleteFile(string filePath);

    }
}
