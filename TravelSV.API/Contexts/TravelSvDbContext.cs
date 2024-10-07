using Microsoft.EntityFrameworkCore;
using TravelSV.API.Models;

namespace TravelSV.API.Contexts
{
    public class TravelSvDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Commerce> Commerces { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public TravelSvDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
