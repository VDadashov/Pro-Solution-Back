using Microsoft.AspNetCore.Http;

namespace ProSolution.BL.Services.ExternalServices
{
    public static class FileManager
    {
        private static readonly string[] AllowedFileTypes = { ".jpg", ".jpeg", ".png" , ".webp" , ".gif" };
        private const long MaxFileSize = 2 * 1024 * 1024;

        public static bool IsValidFile(this IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName).ToLower();
            return file.Length <= MaxFileSize && Array.Exists(AllowedFileTypes, ext => ext == fileExtension);
        }

        public static async Task<string> SaveAsync(this IFormFile file, string folder)
        {
            if (!file.IsValidFile())
                throw new Exception("Invalid file type or size");

            string uploadPath = Path.Combine(Path.GetFullPath("Resource"), "ImageUpload", folder);
            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

            string fileName = Path.GetFileName(file.FileName) + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            using (FileStream fs = new FileStream(Path.Combine(uploadPath, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            return fileName;
        }
    }
}
