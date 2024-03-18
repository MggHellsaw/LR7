using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace LR7.Controllers
{
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Route("File/DownloadFile")]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        [Route("File/DownloadFile")]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, $"wwwroot/{fileName}.txt");

            // Writing the data to the text file
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.WriteLine($"First Name: {firstName}");
                writer.WriteLine($"Last Name: {lastName}");
            }

            // Returning the file for download
            return PhysicalFile(filePath, "text/plain", $"{fileName}.txt");
        }
    }
}
