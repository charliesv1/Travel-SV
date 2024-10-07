using Microsoft.EntityFrameworkCore;
using TravelSV.API.Contexts;
using TravelSV.API.Models;

namespace TravelSV.API.Services
{
    public interface IReviewsService
    {
        Task<IEnumerable<Review>?> GetReviewsAsync();
        Task<Review?> GetReviewByIdAsync(int id);
        Task<Review?> CreateReviewAsync(Review review);
        Task<Review?> UpdateReviewAsync(Review review);
        Task<Review?> DeleteReviewAsync(int id);
    }
    public class ReviewsService : IReviewsService
    {
        private readonly TravelSvDbContext _context;

        public ReviewsService(TravelSvDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>?> GetReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review?> GetReviewByIdAsync(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<Review?> CreateReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review?> UpdateReviewAsync(Review review)
        {
            _context.Entry(review).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review?> DeleteReviewAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return null;
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return review;
        }

    }
}
