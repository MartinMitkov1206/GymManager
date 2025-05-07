using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;           // ← for .Include() & async extensions
using GymManager.Data;
using GymManager.Models;
using GymManager.Models.ViewModels;            // ← for AdminDashboardViewModel
using System.Linq;
using System.Threading.Tasks;


public class AdminsController : Controller
{
    private readonly GymManagerContext _context;
    public AdminsController(GymManagerContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Dashboard()
    {
        var allWorkouts = await _context.Workout
            .Include(w => w.User)
            .ToListAsync();
        var allClients = allWorkouts
            .Select(w => w.User)
            .Distinct()
            .ToList();

        var vm = new AdminDashboardViewModel
        {
            AllWorkouts = allWorkouts,
            AllClients = allClients
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateClientProgress(int clientId, double weight, double benchPress, double squat, double deadlift)
    {
        var stats = await _context.Stats.FirstOrDefaultAsync(s => s.UserID == clientId)
                    ?? new Stats { UserID = clientId };
        stats.Weight = weight;
        stats.BenchPress = benchPress;
        stats.Squat = squat;
        stats.DeadLift = deadlift;
        if (stats.StatsID == 0) _context.Stats.Add(stats);
        await _context.SaveChangesAsync();
		return RedirectToAction("Dashboard", "Admins");
	}
}
