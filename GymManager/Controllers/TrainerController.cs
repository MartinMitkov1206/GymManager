using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using GymManager.Data;
using GymManager.Models;
using GymManager.Models.ViewModels;

namespace GymManager.Controllers
{
    public class TrainersController : Controller
    {
        private readonly GymManagerContext _context;
        public TrainersController(GymManagerContext context)
        {
            _context = context;
        }

        // GET /Trainers/SelectTrainer?trainerId=123
        [HttpGet]
        public IActionResult SelectTrainer(int trainerId)
        {
            // Must be logged in (any user)
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Account");

            HttpContext.Session.SetInt32("SelectedTrainerId", trainerId);
            return RedirectToAction("Index", "Home");
        }

        // GET /Trainers/Dashboard
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            var roleId = HttpContext.Session.GetInt32("RoleID");
            if (userId == null)
            {
                // not logged in
                return RedirectToAction("Login", "Account");
            }
            if (roleId != 4)
            {
                // logged in but not a trainer
                return Forbid();
            }

            // lookup my username (the trainer)
            var myUserName = await _context.User
                .Where(u => u.UserID == userId.Value)
                .Select(u => u.UserName)
                .FirstOrDefaultAsync();

            // grab all bookings where TrainerName == myUserName
            var myWorkouts = await _context.Workout
                .Include(w => w.User)   // the client
                .Where(w => w.TrainerName == myUserName)
                .ToListAsync();

            // distinct clients
            var myClients = myWorkouts
                .Select(w => w.User)
                .Distinct()
                .ToList();

            var vm = new TrainerDashboardViewModel
            {
                MyWorkouts = myWorkouts,
                MyClients = myClients
            };
            return View(vm);
        }

        // POST /Trainers/UpdateClientProgress
        [HttpPost]
        public async Task<IActionResult> UpdateClientProgress(
            int clientId,
            double weight,
            double benchPress,
            double squat,
            double deadlift)
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            var roleId = HttpContext.Session.GetInt32("RoleID");
            if (userId == null)
                return RedirectToAction("Login", "Account");
            if (roleId != 4)
                return Forbid();

            var stats = await _context.Stats
                .FirstOrDefaultAsync(s => s.UserID == clientId)
                ?? new Stats { UserID = clientId };

            stats.Weight = weight;
            stats.BenchPress = benchPress;
            stats.Squat = squat;
            stats.DeadLift = deadlift;

            if (stats.StatsID == 0)
                _context.Stats.Add(stats);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Dashboard));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBooking(int workoutId)
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            var roleId = HttpContext.Session.GetInt32("RoleID");
            if (userId == null)
                return RedirectToAction("Login", "Account");
            if (roleId != 4)
                return Forbid();

            // Lookup my username for safety
            var myUserName = await _context.User
                .Where(u => u.UserID == userId.Value)
                .Select(u => u.UserName)
                .FirstOrDefaultAsync();

            // Only delete if it's actually one of my bookings
            var wk = await _context.Workout
                .FirstOrDefaultAsync(w => w.WorkoutID == workoutId
                                       && w.TrainerName == myUserName);
            if (wk != null)
            {
                _context.Workout.Remove(wk);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Dashboard));
        }
    }
}
