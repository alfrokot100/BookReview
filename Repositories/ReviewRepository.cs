using BookReview.Data;
using BookReview.Models;
using BookReview.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BookReview.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDBContext _context;

        public ReviewRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync(int bookId)
        {
            return await _context.Reviews
                .Where(r => r.BookId_FK == bookId)
                .ToListAsync();
        }

        public async Task<Review?> GetReviewByIdAsync(int reviewId)
        {
            return await _context.Reviews.FindAsync(reviewId);
        }

        public async Task CreateReviewAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }

        public void UpdateReviewAsync(Review review)
        {
            _context.Reviews.Update(review);
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                return false;
            }

            _context.Reviews.Remove(review);
            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
