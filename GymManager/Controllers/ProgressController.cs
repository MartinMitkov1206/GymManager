using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GymManager.Data;
using GymManager.Models;

namespace GymManager.Controllers
{
    public class ProgressController : Controller
    {
        private readonly GymManagerContext _context;
        public ProgressController(GymManagerContext context)
        {
            _context = context;
        }

        // GET: /Progress/Index
        [HttpGet]
        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Retrieve models; if missing, instantiate new ones.
            var goal = _context.Goal.FirstOrDefault(g => g.UserID == userId.Value)
                       ?? new Goal { UserID = userId.Value };
            var stats = _context.Stats.FirstOrDefault(s => s.UserID == userId.Value)
                        ?? new Stats { UserID = userId.Value };

            // We always show values in kg (and cm for height)
            string unit = "kg";
            ViewBag.Unit = unit;

            // Calculate progress percentages (using kg values)
            if (goal.Weight > 0)
            {
                if (stats.Weight > goal.Weight)
                    ViewBag.WeightProgress = Math.Min((goal.Weight / stats.Weight) * 100, 100);
                else
                    ViewBag.WeightProgress = Math.Min((stats.Weight / goal.Weight) * 100, 100);
            }
            else
            {
                ViewBag.WeightProgress = 0;
            }
            ViewBag.BenchPressProgress = goal.BenchPress > 0 ? Math.Min((stats.BenchPress / goal.BenchPress) * 100, 100) : 0;
            ViewBag.SquatProgress = goal.Squat > 0 ? Math.Min((stats.Squat / goal.Squat) * 100, 100) : 0;
            ViewBag.DeadLiftProgress = goal.DeadLift > 0 ? Math.Min((stats.DeadLift / goal.DeadLift) * 100, 100) : 0;

            // Pass the original models (in kg) to the view.
            ViewBag.Goal = goal;
            ViewBag.Stats = stats;

            return View();
        }

        // POST: /Progress/Index
        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Retrieve or create models.
            var goal = _context.Goal.FirstOrDefault(g => g.UserID == userId.Value);
            if (goal == null)
            {
                goal = new Goal { UserID = userId.Value };
                _context.Goal.Add(goal);
            }
            var stats = _context.Stats.FirstOrDefault(s => s.UserID == userId.Value);
            if (stats == null)
            {
                stats = new Stats { UserID = userId.Value };
                _context.Stats.Add(stats);
            }

            // We now always use kg. Parse the form values.
            double.TryParse(form["Goal_Weight"], out double formGoalWeight);
            double.TryParse(form["Goal_BenchPress"], out double formGoalBenchPress);
            double.TryParse(form["Goal_Squat"], out double formGoalSquat);
            double.TryParse(form["Goal_DeadLift"], out double formGoalDeadLift);


            // Round the values to 2 decimals.
            formGoalWeight = Math.Round(formGoalWeight, 2);
            formGoalBenchPress = Math.Round(formGoalBenchPress, 2);
            formGoalSquat = Math.Round(formGoalSquat, 2);
            formGoalDeadLift = Math.Round(formGoalDeadLift, 2);


            // Update the models (values remain in kg)
            goal.Weight = formGoalWeight;
            goal.BenchPress = formGoalBenchPress;
            goal.Squat = formGoalSquat;
            goal.DeadLift = formGoalDeadLift;

            _context.SaveChanges();

            // Recalculate progress percentages.
            int weightProgress;
            if (goal.Weight > 0)
            {
                if (stats.Weight > goal.Weight)
                {
                    // Weight loss scenario: current weight is above the goal
                    weightProgress = (int)Math.Min((goal.Weight / stats.Weight) * 100, 100);
                }
                else
                {
                    // Weight gain scenario: current weight is below the goal
                    weightProgress = (int)Math.Min((stats.Weight / goal.Weight) * 100, 100);
                }
            }
            else
            {
                weightProgress = 0;
            }
            int benchPressProgress = goal.BenchPress > 0 ? (int)Math.Min((stats.BenchPress / goal.BenchPress) * 100, 100) : 0;
            int squatProgress = goal.Squat > 0 ? (int)Math.Min((stats.Squat / goal.Squat) * 100, 100) : 0;
            int deadLiftProgress = goal.DeadLift > 0 ? (int)Math.Min((stats.DeadLift / goal.DeadLift) * 100, 100) : 0;

            ViewBag.WeightProgress = weightProgress;
            ViewBag.BenchPressProgress = benchPressProgress;
            ViewBag.SquatProgress = squatProgress;
            ViewBag.DeadLiftProgress = deadLiftProgress;

            ViewBag.Message = "Your stats and goals have been updated successfully!";

            // Pass the models to the view.
            ViewBag.Goal = goal;
            ViewBag.Stats = stats;

            // Redirect to GET (Post-Redirect-Get pattern) to refresh the view with updated data.
            return RedirectToAction("Index");
        }
    }
}
