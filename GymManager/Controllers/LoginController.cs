using GymManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymManager.Data;
using System.Linq;

namespace GymManager.Controllers
{
    public class LoginController : Controller
    {
        private readonly GymManagerContext _context;

        public LoginController(GymManagerContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Index()
        {
            return View("~/Views/LoginAndRegister/Login.cshtml");
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Username and password cannot be empty!";
                return View("~/Views/LoginAndRegister/Login.cshtml");
            }

            var user = _context.User
                .Where(u => u.UserName == userName && u.Password == password)
                .FirstOrDefault();

            if (user != null)
            {
                // Simulate user login (you can use Session or Cookie here)
                // For now, we'll just redirect to another page (e.g., Dashboard)
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password!";
                return View("~/Views/LoginAndRegister/Login.cshtml");
            }
        }
    }
}
