using Microsoft.AspNetCore.Http;


namespace ExpenseManagementSystem.Application.Helpers
{
    public class FileHelper
    {
        public static async Task<string> SaveFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Dosya boş olamaz.");


            var wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var uploadPath = Path.Combine(wwwRootPath, "uploads");


            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);


            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var fullPath = Path.Combine(uploadPath, fileName);


            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine("uploads",fileName).Replace("\\", "/");
        }
    }
}

