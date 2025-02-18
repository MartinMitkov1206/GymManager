using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.Models
{
    public class PasswordResetToken
    {
        [Key]
        public int TokenID { get; set; }

        [Required]
        public string Token { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }

        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow.AddHours(1);
    }
}
