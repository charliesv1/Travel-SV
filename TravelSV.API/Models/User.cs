using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace TravelSV.API.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public record class User
    {
        [Key]
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public bool Active { get; set; } = true;

        [ForeignKey(nameof(Role))]
        public required Guid RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
