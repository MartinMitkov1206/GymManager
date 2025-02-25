using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace GymManager.Controllers
{
    public class WorkoutsController : Controller
    {
        [HttpGet]
        public IActionResult Schedule()
        {
            // Check if the user is logged in
            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Check if a trainer was selected (stored in session)
            int? trainerId = HttpContext.Session.GetInt32("SelectedTrainerId");
            if (trainerId == null)
            {
                // No trainer selected, redirect to trainers page
                return RedirectToAction("Index", "Trainers");
            }

            // Pass the selected trainer ID to the view
            return View(model: trainerId.Value);
        }

        [HttpPost]
        public IActionResult Schedule(int trainerId, string selectedDate, string selectedTime, string trainingType)
        {
            // Check if the user is logged in
            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Validate the input
            if (string.IsNullOrEmpty(selectedDate) || string.IsNullOrEmpty(selectedTime))
            {
                // Missing date or time; re-display the form
                return RedirectToAction("Schedule");
            }

            // Parse the date/time if needed (for example)
            // DateTime bookingDateTime = DateTime.Parse($"{selectedDate} {selectedTime}");

            // Save the booking or perform additional processing here

            return RedirectToAction("Index", "Home");
        }
    }
}
