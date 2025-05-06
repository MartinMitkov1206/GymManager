namespace GymManager.Models.ViewModels
{
    public class TrainerDashboardViewModel
    {
        // All the workouts booked with this trainer
        public List<Workout> MyWorkouts { get; set; }

        // The distinct list of clients who have workouts with me
        public List<User> MyClients { get; set; }
    }

}
