using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.Models
{
    public class TrainerClient
    {
        [Key]
        public int TrainerClientID { get; set; }

        // The Trainer's user account (must be a trainer)
        [Required]
        public int TrainerID { get; set; }
        [ForeignKey("TrainerID")]
        public User? Trainer { get; set; }

        // The Client's user account (a user assigned to a trainer)
        [Required]
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public User ?Client { get; set; }

    }
}
