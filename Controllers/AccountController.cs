using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using cpis358e2.Data;
using cpis358e2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace cpis358e2.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("username", user.Username);
                Response.Cookies.Append("username", user.Username);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "اسم المستخدم أو كلمة المرور غير صحيحة!";
                return View();
            }
        }

        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(string username, string name, string email, string password)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Username = username,
                    FullName = name,
                    Email = email,
                    Password = password
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                HttpContext.Session.SetString("username", username);
                Response.Cookies.Append("username", username);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("username");
            return RedirectToAction("Login");
        }
    }
}
