using Microsoft.EntityFrameworkCore;
using TravelSV.API.Contexts;
using TravelSV.API.Models;

namespace TravelSV.API.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>?> GetProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product?> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(Product product);
        Task<Product?> DeleteProductAsync(int id);
    }
    public class ProductsService : IProductsService
    {
        private readonly TravelSvDbContext _context;

        public ProductsService(TravelSvDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>?> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product?> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
