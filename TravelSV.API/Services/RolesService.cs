using Microsoft.EntityFrameworkCore;
using TravelSV.API.Contexts;
using TravelSV.API.Models;

namespace TravelSV.API.Services
{
    public interface IRolesService
    {
        Task<Role> CreateRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task<Role?> DeleteRoleAsync(Guid id);
        Task<Role?> GetRoleByIdAsync(Guid id);
        Task<IEnumerable<Role>?> GetRolesAsync();
    }

    public class RolesService : IRolesService
    {
        private readonly TravelSvDbContext _context;

        public RolesService(TravelSvDbContext context)
        {
            _context = context;
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role?> DeleteRoleAsync(Guid id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return null;
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role?> GetRoleByIdAsync(Guid id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<IEnumerable<Role>?> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
