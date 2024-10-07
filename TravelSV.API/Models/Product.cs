using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelSV.API.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public record class Product
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required List<string>? ImagesUrl { get; set; }
        public required decimal Price { get; set; }
        public bool Active { get; set; } = true;
        public bool IsPromotion { get; set; } = false;
        public decimal PromotionPrice { get; set; }

        [ForeignKey(nameof(ProductCategory))]
        public required Guid ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; } = null!;
    }
}
