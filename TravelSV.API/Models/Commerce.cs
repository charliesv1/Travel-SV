using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelSV.API.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public record class Commerce
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }

        [ForeignKey(nameof(User))]
        public required Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
