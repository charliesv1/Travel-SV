using Microsoft.EntityFrameworkCore;
using TravelSV.API.Contexts;
using TravelSV.API.Models;

namespace TravelSV.API.Services
{
    public interface ICommercesService
    {
        Task<Commerce?> CreateCommerce(Commerce commerce);
        Task<Commerce?> GetCommerceById(int id);
        Task<IEnumerable<Commerce>?> GetCommerces();
        Task<Commerce?> UpdateCommerce(Commerce commerce);
        Task<Commerce?> DeleteCommerce(int id);
    }
    public class CommercesService : ICommercesService
    {
        private readonly TravelSvDbContext _context;

        public CommercesService(TravelSvDbContext context)
        {
            _context = context;
        }

        public async Task<Commerce?> CreateCommerce(Commerce commerce)
        {
            _context.Commerces.Add(commerce);
            await _context.SaveChangesAsync();
            return commerce;
        }

        public async Task<Commerce?> GetCommerceById(int id)
        {
            return await _context.Commerces.FindAsync(id);
        }

        public async Task<IEnumerable<Commerce>?> GetCommerces()
        {
            return await _context.Commerces.ToListAsync();
        }

        public async Task<Commerce?> UpdateCommerce(Commerce commerce)
        {
            _context.Entry(commerce).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return commerce;
        }

        public async Task<Commerce?> DeleteCommerce(int id)
        {
            var commerce = await _context.Commerces.FindAsync(id);
            if (commerce == null)
            {
                return null;
            }

            _context.Commerces.Remove(commerce);
            await _context.SaveChangesAsync();
            return commerce;
        }
    }
}
