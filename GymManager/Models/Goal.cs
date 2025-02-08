using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.Models
{
    public class Goal
    {
        [Key]
        public int GoalID { get; set; }
        public double Weight { get; set; }
        public double BenchPress { get; set; }
        public double Squat { get; set; }
        public double DeadLift { get; set; }

        public int UserID { get; set; } 

        [ForeignKey("UserID")]
        public User User { get; set; } 
    }

}
