using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using GymManager.Models;
using GymManager.Helpers;
using GymManager.Data;
using GymManager.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly GymManagerContext _context;


        public AccountController(GymManagerContext context)
        {
            _context = context;
        }

        // ** REGISTER **
        [HttpGet]
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // 🔹 Check if email is already registered
            if (_context.User.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("", "Email is already registered.");
                return View(model);
            }

            // 🔹 Generate Salt and Hash Password
            string salt = PasswordHelper.GenerateSalt();
            string hashedPassword = PasswordHelper.HashPassword(model.Password, salt);

            // 🔹 Find the "User" role in the database
            var defaultRole = _context.Role.FirstOrDefault(r => r.RoleType == "User");

            if (defaultRole == null)
            {
                ModelState.AddModelError("", "Default role 'User' not found in database.");
                return View(model);
            }

            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Age = model.Age,
                RoleID = defaultRole.RoleID, // Set default role
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                IsEmailConfirmed = false
            };

            _context.User.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }



        // ** LOGIN **
        [HttpGet]
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // 🔹 Find user by email
            var user = _context.User.SingleOrDefault(u => u.Email == model.Email);

            // 🔹 Verify user credentials
            if (user == null || !PasswordHelper.VerifyPassword(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            // 🔹 Store session details
            HttpContext.Session.SetInt32("UserID", user.UserID);
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetInt32("RoleID", user.RoleID);

            return RedirectToAction("Index", "Home");
        }


        // ** LOGOUT **
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("GymManagerAuth"); // Use "GymManagerAuth" here
            HttpContext.Session.Clear(); // Clear session
            return RedirectToAction("Login");
        }

    }
}
