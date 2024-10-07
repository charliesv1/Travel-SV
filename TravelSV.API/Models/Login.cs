using System.ComponentModel.DataAnnotations;

namespace TravelSV.API.Models
{
    public class Login
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
