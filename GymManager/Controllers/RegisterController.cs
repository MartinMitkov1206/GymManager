using GymManager.Data;
using GymManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GymManager.Controllers
{
    public class RegisterController : Controller
    {
        private readonly GymManagerContext _context;

        public RegisterController(GymManagerContext context)
        {
            _context = context;
        }

        // GET: /Register
        public IActionResult Index()
        {
            return View("~/Views/LoginAndRegister/Register.cshtml");
        }

        // POST: /Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string userName, string email, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.ErrorMessage = "Passwords do not match!";
                return View("~/Views/LoginAndRegister/Register.cshtml");

            }

            // Check if the user already exists
            var existingUser = _context.User.FirstOrDefault(u => u.UserName == userName || u.Email == email);
            if (existingUser != null)
            {
                ViewBag.ErrorMessage = "User already exists!";
                return View("~/Views/LoginAndRegister/Register.cshtml");

            }

            // Create new user and add to the database
            var newUser = new User
            {
                UserName = userName,
                Email = email,
                Password = password, // In real life, hash the password before saving it
                Age = 0, // You can add a field for age if needed, or remove if not required
                Role = new Role() // Assign a default role or set it to a specific one
            };

            _context.User.Add(newUser);
            _context.SaveChanges();

            // Redirect to the login page after successful registration
            return RedirectToAction("Index", "Login");
        }
    }
}
