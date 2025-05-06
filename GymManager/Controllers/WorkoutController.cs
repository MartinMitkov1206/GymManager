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
            // ensure logged in
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Account");

            // must have date/time
            if (string.IsNullOrEmpty(selectedDate) || string.IsNullOrEmpty(selectedTime))
            {
                TempData["ErrorMessage"] = "Please choose both a date and a time.";
                return RedirectToAction("Schedule", new { trainerId });
            }

            // parse into a DateTime
            if (!DateTime.TryParse($"{selectedDate} {selectedTime}", out var booking))
            {
                TempData["ErrorMessage"] = "Could not understand that date/time.";
                return RedirectToAction("Schedule", new { trainerId });
            }

            // no past bookings
            if (booking < DateTime.Now)
            {
                TempData["ErrorMessage"] = "You can’t schedule a session in the past.";
                return RedirectToAction("Schedule", new { trainerId });
            }

            // TODO: save your booking to the database here...

            return RedirectToAction("Index", "Home");
        }
    }
    }

