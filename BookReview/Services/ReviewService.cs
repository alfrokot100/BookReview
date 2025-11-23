using BookReview.Data;
using BookReview.DTOs.ReviewDTOs;
using BookReview.Models;
using BookReview.Repositories.IRepositories;
using BookReview.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BookReview.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepo;

        public ReviewService(IReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllReviewsAsync(int bookId)
        {
            var reviews = await _reviewRepo.GetAllReviewsAsync(bookId);
            return reviews.Select(r => new ReviewDTO
            {
                Id = r.Id,
                ReviewerName = r.ReviewerName,
                Rating = r.Rating,
                Text = r.Text,
                CreatedDate = r.CreatedDate,
                BookId = r.BookId_FK

            });
        }

        public async Task<ReviewDTO?> GetReviewByIdAsync(int reviewId)
        {
            var review = await _reviewRepo.GetReviewByIdAsync(reviewId);
            if (review == null) return null;
            return new ReviewDTO
            {
                Id = review.Id,
                ReviewerName = review.ReviewerName,
                Rating = review.Rating,
                Text = review.Text,
                CreatedDate = review.CreatedDate,
                BookId = review.BookId_FK
            };
        }

        public async Task<ReviewDTO?> CreateReviewToBookAsync(int bookId, CreateReviewDTO createReviewDTO)
        {
            var review = new Review
            {
                ReviewerName = createReviewDTO.ReviewerName,
                Rating = createReviewDTO.Rating,
                Text = createReviewDTO.Text,
                BookId_FK = bookId,
            };

            await _reviewRepo.CreateReviewAsync(review);
            await _reviewRepo.SaveChangesAsync();

            return new ReviewDTO
            {
                Id = review.Id,
                ReviewerName = review.ReviewerName,
                Rating = review.Rating,
                Text = review.Text,
                CreatedDate = review.CreatedDate,
                BookId = review.BookId_FK
            };
        }

        public async Task<bool> UpdateReviewAsync(int reviewId, UpdateReviewDTO updateReviewDTO)
        {
            var review = await _reviewRepo.GetReviewByIdAsync(reviewId);
            if (review == null) return false;

            review.Rating = updateReviewDTO.Rating; 
            review.Text = updateReviewDTO.Text;

            _reviewRepo.UpdateReviewAsync(review);
            return await _reviewRepo.SaveChangesAsync();
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            await _reviewRepo.DeleteReviewAsync(reviewId);
            return await _reviewRepo.SaveChangesAsync();
        }


    }
}
