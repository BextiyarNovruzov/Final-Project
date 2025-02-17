using Gymon.BL.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.BL.Services.Imlements
{
    public class FileService(IWebHostEnvironment web) : IFileService
    {
        private readonly string _uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imgs");
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png" };
        private const int MaxFileSize = 5 * 1024 * 1024; //
                                                         // 


        public async Task<string> SaveImageAsync(IFormFile file, string folderPath)
        {
            if (file == null || file.Length == 0)
                return string.Empty;

            // Create the directory if it does not exist
            Directory.CreateDirectory(folderPath);

            // Generate a unique file name
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(folderPath, fileName);

            // Save the file to the directory
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName;
        }


        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Dosya boş olamaz.");

            var extension = Path.GetExtension(file.FileName).ToLower();
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(extension))
                throw new ArgumentException("Sadece .jpg, .jpeg veya .png uzantılı dosyalar yüklenebilir.");

            if (file.Length > 5 * 1024 * 1024) // 5MB
                throw new ArgumentException("Dosya boyutu 5MB'dan küçük olmalıdır.");

            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(_uploadDirectory, fileName);

            // Dosya yükleme işlemi
            Directory.CreateDirectory(_uploadDirectory);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/imgs/{fileName}"; // URL olarak döndürülür
        }

        public void DeleteFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return;

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath.TrimStart('/'));

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath); // Eski dosyayı sil
            }
        }
    }
}
