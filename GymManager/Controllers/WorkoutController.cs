using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using GymManager.Models;
using GymManager.Data;

namespace GymManager.Controllers
{
    public class WorkoutsController : Controller
    {
        private readonly GymManagerContext _context;


        public WorkoutsController(GymManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Schedule()
        {
            // 1) Must be logged in
            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
                return RedirectToAction("Login", "Account");

            // 2) Must have picked a trainer
            int? trainerId = HttpContext.Session.GetInt32("SelectedTrainerId");
            if (trainerId == null)
            {
                TempData["ErrorMessage"] = "Please select a trainer before scheduling.";
                return RedirectToAction("Index", "Home");
            }

            // 3) Look up their name
            var trainerName = _context.User
                                      .Where(u => u.UserID == trainerId.Value)
                                      .Select(u => u.UserName)
                                      .FirstOrDefault()
                                ?? "Unknown";
            ViewBag.TrainerName = trainerName;

            // 4) Finally render the page
            return View(model: trainerId.Value);
        }



        [HttpPost]
        public IActionResult Schedule(int trainerId, string selectedDate, string selectedTime, string trainingType, int duration, int workoutTypeId)
        {
            // ensure is logged in
            if (HttpContext.Session.GetInt32("UserID") == null)
                return RedirectToAction("Login", "Account");

            // must have date/time
            if (string.IsNullOrEmpty(selectedDate) || string.IsNullOrEmpty(selectedTime))
            {
                TempData["ErrorMessage"] = "Please choose both a date and a time.";
                return RedirectToAction("Schedule", new { trainerId });
            }

            // parse into a datetime
            if (!DateTime.TryParse($"{selectedDate} {selectedTime}", out var bookingDate))
            {
                TempData["ErrorMessage"] = "Could not understand that date/time.";
                return RedirectToAction("Schedule", new { trainerId });
            }

            // no past bookings
            if (bookingDate < DateTime.Now)
            {
                TempData["ErrorMessage"] = "You can't schedule a session in the past.";
                return RedirectToAction("Schedule", new { trainerId });
            }

            var trainer = _context.User.FirstOrDefault(u => u.UserID == trainerId);
            if (trainer == null)
            {
                TempData["ErrorMessage"] = "Trainer not found.";
                return RedirectToAction("Schedule", new { trainerId });
            }


            var booking = new Workout
            {
                UserID = (int)HttpContext.Session.GetInt32("UserID"),
                TrainerName = trainer.UserName,
                Duration = duration,
                WorkoutTypeID = workoutTypeId,
                IsIndividual = trainingType == "Individual",
                ScheduledAt = bookingDate
            };

            _context.Workout.Add(booking);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
    }

