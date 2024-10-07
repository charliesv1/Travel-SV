using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TravelSV.API.Contexts;
using TravelSV.API.Models;

namespace TravelSV.API.Services
{
    public interface IUsersService
    {
        Task<User?> CreateUser(User user);
        Task<User?> UpdateUser(User user);
        Task<User?> DeleteUser(Guid id);
        Task<IEnumerable<User>?> GetUsers();
        Task<User?> GetUserByCriteria(Expression<Func<User, bool>> criteria);
    }

    public class UsersService : IUsersService
    {
        private readonly TravelSvDbContext _context;

        public UsersService(TravelSvDbContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateUser(User user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User?> UpdateUser(User user)
        {
            var result = _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User?> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            var result = _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<User>?> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByCriteria(Expression<Func<User, bool>> criteria)
        {
            return await _context.Users.SingleOrDefaultAsync(criteria);
        }
    }
}
