using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace GymManager.Controllers
{
    public class TrainersController : Controller
    {
        // If you already have an Index or other actions, keep them.

        [HttpGet]
        public IActionResult SelectTrainer(int trainerId)
        {
            // Store the selected trainer ID in session
            HttpContext.Session.SetInt32("SelectedTrainerId", trainerId);

            // Redirect back to Home page (or wherever you prefer)
            return RedirectToAction("Index", "Home");
        }
    }
}
