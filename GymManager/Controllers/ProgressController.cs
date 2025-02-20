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

            // Retrieve existing models; if missing, instantiate new ones.
            var goal = _context.Goal.FirstOrDefault(g => g.UserID == userId.Value) ?? new Goal { UserID = userId.Value };
            var stats = _context.Stats.FirstOrDefault(s => s.UserID == userId.Value) ?? new Stats { UserID = userId.Value };

            // Check for unit parameter in the query string; default is "kg".
            string unit = Request.Query["unit"];
            if (string.IsNullOrEmpty(unit))
            {
                unit = "kg";
            }
            ViewBag.Unit = unit;

            // Calculate progress percentages (the ratio remains the same regardless of units)
            ViewBag.WeightProgress = goal.Weight > 0 ? Math.Min((stats.Weight / goal.Weight) * 100, 100) : 0;
            ViewBag.BenchPressProgress = goal.BenchPress > 0 ? Math.Min((stats.BenchPress / goal.BenchPress) * 100, 100) : 0;
            ViewBag.SquatProgress = goal.Squat > 0 ? Math.Min((stats.Squat / goal.Squat) * 100, 100) : 0;
            ViewBag.DeadLiftProgress = goal.DeadLift > 0 ? Math.Min((stats.DeadLift / goal.DeadLift) * 100, 100) : 0;

            // Prepare copies for display so we don't modify DB values.
            var displayGoal = new Goal
            {
                Weight = goal.Weight,
                BenchPress = goal.BenchPress,
                Squat = goal.Squat,
                DeadLift = goal.DeadLift,
                UserID = goal.UserID
            };
            var displayStats = new Stats
            {
                Weight = stats.Weight,
                BenchPress = stats.BenchPress,
                Squat = stats.Squat,
                DeadLift = stats.DeadLift,
                UserID = stats.UserID
            };

            // If user has selected lbs, convert the displayed values.
            if (unit == "lbs")
            {
                displayGoal.Weight = Math.Round(goal.Weight * 2.20462, 1);
                displayGoal.BenchPress = Math.Round(goal.BenchPress * 2.20462, 1);
                displayGoal.Squat = Math.Round(goal.Squat * 2.20462, 1);
                displayGoal.DeadLift = Math.Round(goal.DeadLift * 2.20462, 1);

                displayStats.Weight = Math.Round(stats.Weight * 2.20462, 1);
                displayStats.BenchPress = Math.Round(stats.BenchPress * 2.20462, 1);
                displayStats.Squat = Math.Round(stats.Squat * 2.20462, 1);
                displayStats.DeadLift = Math.Round(stats.DeadLift * 2.20462, 1);
            }

            ViewBag.Goal = displayGoal;
            ViewBag.Stats = displayStats;

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

            // Read unit selection from the form.
            string unit = form["Unit"];
            ViewBag.Unit = unit;

            // Parse form values.
            double.TryParse(form["Goal_Weight"], out double formGoalWeight);
            double.TryParse(form["Goal_BenchPress"], out double formGoalBenchPress);
            double.TryParse(form["Goal_Squat"], out double formGoalSquat);
            double.TryParse(form["Goal_DeadLift"], out double formGoalDeadLift);
            double.TryParse(form["Stats_Weight"], out double formStatsWeight);
            double.TryParse(form["Stats_BenchPress"], out double formStatsBenchPress);
            double.TryParse(form["Stats_Squat"], out double formStatsSquat);
            double.TryParse(form["Stats_DeadLift"], out double formStatsDeadLift);

            // If unit is lbs, convert input values to kg before saving.
            if (unit == "lbs")
            {
                formGoalWeight = formGoalWeight / 2.20462;
                formGoalBenchPress = formGoalBenchPress / 2.20462;
                formGoalSquat = formGoalSquat / 2.20462;
                formGoalDeadLift = formGoalDeadLift / 2.20462;

                formStatsWeight = formStatsWeight / 2.20462;
                formStatsBenchPress = formStatsBenchPress / 2.20462;
                formStatsSquat = formStatsSquat / 2.20462;
                formStatsDeadLift = formStatsDeadLift / 2.20462;
            }

            // Update models with converted values.
            goal.Weight = formGoalWeight;
            goal.BenchPress = formGoalBenchPress;
            goal.Squat = formGoalSquat;
            goal.DeadLift = formGoalDeadLift;

            stats.Weight = formStatsWeight;
            stats.BenchPress = formStatsBenchPress;
            stats.Squat = formStatsSquat;
            stats.DeadLift = formStatsDeadLift;

            _context.SaveChanges();

            // Recalculate progress percentages.
            int weightProgress = goal.Weight > 0 ? (int)Math.Min((stats.Weight / goal.Weight) * 100, 100) : 0;
            int benchPressProgress = goal.BenchPress > 0 ? (int)Math.Min((stats.BenchPress / goal.BenchPress) * 100, 100) : 0;
            int squatProgress = goal.Squat > 0 ? (int)Math.Min((stats.Squat / goal.Squat) * 100, 100) : 0;
            int deadLiftProgress = goal.DeadLift > 0 ? (int)Math.Min((stats.DeadLift / goal.DeadLift) * 100, 100) : 0;

            ViewBag.WeightProgress = weightProgress;
            ViewBag.BenchPressProgress = benchPressProgress;
            ViewBag.SquatProgress = squatProgress;
            ViewBag.DeadLiftProgress = deadLiftProgress;

            ViewBag.Message = "Your stats and goals have been updated successfully!";

            // Prepare display copies to show values in the selected unit.
            var displayGoal = new Goal
            {
                Weight = goal.Weight,
                BenchPress = goal.BenchPress,
                Squat = goal.Squat,
                DeadLift = goal.DeadLift,
                UserID = goal.UserID
            };
            var displayStats = new Stats
            {
                Weight = stats.Weight,
                BenchPress = stats.BenchPress,
                Squat = stats.Squat,
                DeadLift = stats.DeadLift,
                UserID = stats.UserID
            };

            if (unit == "lbs")
            {
                displayGoal.Weight = Math.Round(goal.Weight * 2.20462, 1);
                displayGoal.BenchPress = Math.Round(goal.BenchPress * 2.20462, 1);
                displayGoal.Squat = Math.Round(goal.Squat * 2.20462, 1);
                displayGoal.DeadLift = Math.Round(goal.DeadLift * 2.20462, 1);

                displayStats.Weight = Math.Round(stats.Weight * 2.20462, 1);
                displayStats.BenchPress = Math.Round(stats.BenchPress * 2.20462, 1);
                displayStats.Squat = Math.Round(stats.Squat * 2.20462, 1);
                displayStats.DeadLift = Math.Round(stats.DeadLift * 2.20462, 1);
            }

            ViewBag.Goal = displayGoal;
            ViewBag.Stats = displayStats;

            return View();
        }
    }
}
