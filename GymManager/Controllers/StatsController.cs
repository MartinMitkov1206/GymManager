using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GymManager.Data;
using GymManager.Models;

namespace GymManager.Controllers
{
    public class StatsController : Controller
    {
        private readonly GymManagerContext _context;
        public StatsController(GymManagerContext context)
        {
            _context = context;
        }

        // GET: /Stats/Enter
        [HttpGet]
        public IActionResult Enter()
        {
            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Check if stats already exist for the user.
            var stats = _context.Stats.FirstOrDefault(s => s.UserID == userId.Value);
            if (stats == null)
            {
                stats = new Stats { UserID = userId.Value };
            }

            return View(stats);
        }

        // POST: /Stats/Enter
        [HttpPost]
        public IActionResult Enter(Stats stats)
        {
            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Ensure the stats belong to the current user.
            stats.UserID = userId.Value;

            // Check if there's already an entry for this user.
            var existingStats = _context.Stats.FirstOrDefault(s => s.UserID == userId.Value);
            if (existingStats == null)
            {
                _context.Stats.Add(stats);
            }
            else
            {
                // Update the existing record.
                existingStats.Weight = stats.Weight;
                existingStats.Height = stats.Height;
                existingStats.Workouts = stats.Workouts;
                existingStats.BenchPress = stats.BenchPress;
                existingStats.Squat = stats.Squat;
                existingStats.DeadLift = stats.DeadLift;
                _context.Stats.Update(existingStats);
            }

            _context.SaveChanges();

            // Optionally, redirect to a dashboard or another page
            return RedirectToAction("Index", "Home");
        }
    }
}
