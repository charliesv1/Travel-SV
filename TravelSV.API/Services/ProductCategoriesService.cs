using Microsoft.EntityFrameworkCore;
using TravelSV.API.Contexts;
using TravelSV.API.Models;

namespace TravelSV.API.Services
{
    public interface IProductCategoriesService
    {
        Task<IEnumerable<ProductCategory>?> GetProductCategories();
        Task<ProductCategory?> GetProductCategory(int id);
        Task<ProductCategory?> CreateProductCategory(ProductCategory productCategory);
        Task<ProductCategory?> UpdateProductCategory(ProductCategory productCategory);
        Task<ProductCategory?> DeleteProductCategory(int id);
    }
    public class ProductCategoriesService : IProductCategoriesService
    {
        private readonly TravelSvDbContext _context;

        public ProductCategoriesService(TravelSvDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductCategory>?> GetProductCategories()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory?> GetProductCategory(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }

        public async Task<ProductCategory?> CreateProductCategory(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();
            return productCategory;
        }

        public async Task<ProductCategory?> UpdateProductCategory(ProductCategory productCategory)
        {
            _context.Entry(productCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return productCategory;
        }

        public async Task<ProductCategory?> DeleteProductCategory(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return null;
            }

            _context.ProductCategories.Remove(productCategory);
            await _context.SaveChangesAsync();
            return productCategory;
        }
    }
}
