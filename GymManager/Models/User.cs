using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Store hashed password

        public string PasswordSalt { get; set; } // Store salt for hashing

        [Required, EmailAddress]
        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; } = false;

        // Remove the 'Age' field, and replace it with DateOfBirth:
        [Required]
        public int Age{ get; set; }

        // If you still have roles:
        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Role Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
