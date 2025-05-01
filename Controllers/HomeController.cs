using System.Diagnostics;
using cpis358e2.Models;
using Microsoft.AspNetCore.Mvc;

namespace cpis358e2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Course1()
        {
            return View();
        }

        public IActionResult Course2()
        {
            return View();
        }

        public IActionResult Course3()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Upload(IFormFile uploadedFile)
        {
            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var filePath = Path.Combine(uploadsFolder, uploadedFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    uploadedFile.CopyTo(stream);
                }

                ViewBag.Message = "☑️ تم رفع الملف بنجاح!";
            }
            else
            {
                ViewBag.Message = "⚠️ لم يتم تحديد أي ملف.";
            }

            return View();
        }




    }
}
