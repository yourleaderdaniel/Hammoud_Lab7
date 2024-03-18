using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace Lab7.Controllers
{
    public class FileController : Controller
    {
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            
            string filesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

            
            if (!Directory.Exists(filesFolder))
            {
                Directory.CreateDirectory(filesFolder);
            }

            
            string filePath = Path.Combine(filesFolder, fileName + ".txt");

            
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.WriteLine($"Имя: {firstName}");
                writer.WriteLine($"Фамилия: {lastName}");
            }

            
            return PhysicalFile(filePath, "text/plain", fileName + ".txt");
        }
    }
}
