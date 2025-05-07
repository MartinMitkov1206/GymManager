using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GymManager.Data;
using GymManager.Helpers;
using GymManager.Models;
using GymManager.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;

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

        // Show the empty form
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Handle the form POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            // 1) Validate required fields (email/password/etc)
            if (!ModelState.IsValid)
                return View(model);

            // 2) Reject duplicate emails
            if (_context.User.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("", "Email is already registered.");
                return View(model);
            }

            // 3) Hash the password
            string salt = PasswordHelper.GenerateSalt();
            string hashedPassword = PasswordHelper.HashPassword(model.Password, salt);

            // 4) Look up the "User" role
            var defaultRole = _context.Role.FirstOrDefault(r => r.RoleType == "User");
            if (defaultRole == null)
            {
                ModelState.AddModelError("", "Default role 'User' not found in database.");
                return View(model);
            }

            // 5) Calculate age from the DateOfBirth field
            int age = CalcAgeHelper.CalceAge(model.DateOfBirth);

            // 6) Create and save the user
            var user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Age = age,
                RoleID = defaultRole.RoleID,
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                IsEmailConfirmed = false
            };

            _context.User.Add(user);
            _context.SaveChanges();

            // 7) After successful register, send them to login
            return RedirectToAction("Login");
        }

        // ** LOGIN ** (unchanged)
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _context.User.SingleOrDefault(u => u.Email == model.Email);
            if (user == null || !PasswordHelper.VerifyPassword(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }

            HttpContext.Session.SetInt32("UserID", user.UserID);
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetInt32("RoleID", user.RoleID);

            return RedirectToAction("Enter", "Stats");
        }

        // ** LOGOUT ** (unchanged)
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("GymManagerAuth");
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
