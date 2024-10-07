using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelSV.API.Models
{
    public record class Review
    {
        [Key]
        public Guid Id { get; set; }
        public required string Description { get; set; }
        public required decimal Rate  { get; set; }

        [ForeignKey(nameof(User))]
        public required Guid UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(Product))]
        public required Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
