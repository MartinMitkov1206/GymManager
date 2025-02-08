using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.Models
{
    public class Workout
    {
        [Key]
        public int WorkoutID { get; set; }
        public double Duration { get; set; }
        public string TrainerName { get; set; }
        public int WorkoutTypeID { get; set; }
        public bool IsIndividual { get; set; }
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

    }
}
