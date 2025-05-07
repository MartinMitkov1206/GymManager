using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GymManager.Data;
using GymManager.Models;

namespace GymManager.Controllers
{
    public class WorkoutStatsController : Controller
    {
        private readonly GymManagerContext _context;
        public WorkoutStatsController(GymManagerContext context)
        {
            _context = context;
        }

        // GET: /WorkoutStats/Index
        [HttpGet]
        public IActionResult Index()
        {
            // 1) Must be logged in
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            // 2) Load overall stats (or new one if missing)
            var overallStats = _context.Stats
                .FirstOrDefault(s => s.UserID == userId.Value)
                ?? new Stats { UserID = userId.Value };

            // 3) Load *all* workouts for this user
            var workouts = _context.Workout
                .Where(w => w.UserID == userId.Value)
                .ToList();

            // 4) Ensure the total-workouts counter is correct
            overallStats.Workouts = workouts.Count;

            // 5) Stuff into ViewBag for the view
            ViewBag.OverallStats = overallStats;
            ViewBag.Workouts = workouts;

            // 6) New: pass through your “unit” (if you ever switch kg/lbs)
            ViewBag.Unit = HttpContext.Session.GetString("Unit") ?? "kg";

            // 7) New: grab the user’s age from their profile
            var user = _context.User.Find(userId.Value);
            ViewBag.UserAge = user?.Age;

            return View();
        }
    }
}
