using System.ComponentModel.DataAnnotations;

namespace GymManager.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

    }
}
