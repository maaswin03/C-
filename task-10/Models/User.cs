using System.ComponentModel.DataAnnotations;

namespace Task_10.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}