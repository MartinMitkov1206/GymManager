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
			// Check if the user is logged in
			int? userId = HttpContext.Session.GetInt32("UserID");
			if (userId == null)
			{
				return RedirectToAction("Login", "Account");
			}

			// Retrieve overall stats for the current user
			var overallStats = _context.Stats.FirstOrDefault(s => s.UserID == userId.Value);

			// Retrieve all workouts for the current user
			List<Workout> workouts = _context.Workout.Where(w => w.UserID == userId.Value).ToList();

			// Retrieve the workout statistics for the selected workout (if any)
			WorkoutStats selectedWorkoutStats = null;
			if (workoutId.HasValue)
			{
				selectedWorkoutStats = _context.WorkoutStats.FirstOrDefault(ws => ws.WorkoutID == workoutId.Value);
			}

			// Retrieve the user record so we can pass the Age to the view.
			var user = _context.User.FirstOrDefault(u => u.UserID == userId.Value);
			ViewBag.UserAge = user?.Age;

			// Pass the data to the view via ViewBag
			ViewBag.OverallStats = overallStats;
			ViewBag.Workouts = workouts;
			ViewBag.SelectedWorkoutStats = selectedWorkoutStats;
			ViewBag.SelectedWorkoutID = workoutId;

			return View();
		}
	}
}
