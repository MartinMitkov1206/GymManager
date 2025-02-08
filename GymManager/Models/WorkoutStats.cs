using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.Models
{
    public class WorkoutStats
    {
        [Key]
        public string WorkoutStatID { get; set; }
        [ForeignKey("WorkoutID")]
        public Workout Workout { get; set; }
        public int WorkoutID { get; set; }
        public double WorkoutStat { get; set; }

    }
}
