using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GymManager.Data;
using GymManager.Models;
using System.Collections.Generic;

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
        // Optional parameter workoutId lets the user pick a specific workout.
        [HttpGet]
        public IActionResult Index(int? workoutId)
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            // get the user’s stored Stats (weight, bench, etc)
            var overallStats = _context.Stats
                               .FirstOrDefault(s => s.UserID == userId.Value)
                           ?? new Stats { UserID = userId.Value };

            // grab every workout they’ve ever done
            var workouts = _context.Workout
                            .Where(w => w.UserID == userId.Value)
                            .ToList();

            // override the Stats.Workouts field so it always reflects the true count
            overallStats.Workouts = workouts.Count;

            // now stick everything in the ViewBag
            ViewBag.OverallStats = overallStats;
            ViewBag.Workouts = workouts;
            ViewBag.SelectedWorkoutStats = workoutId.HasValue
                  ? _context.WorkoutStats.FirstOrDefault(ws => ws.WorkoutID == workoutId.Value)
                  : null;
            ViewBag.SelectedWorkoutID = workoutId;

            return View();
        }

    }
}

