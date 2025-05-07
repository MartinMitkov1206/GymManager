using GymManager.Models;
using System.Collections.Generic;

namespace GymManager.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public List<Workout> AllWorkouts { get; set; }
        public List<User> AllClients { get; set; }
    }
}
