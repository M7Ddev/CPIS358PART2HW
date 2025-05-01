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


    }
}
