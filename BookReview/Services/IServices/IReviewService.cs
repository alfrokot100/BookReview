using BookReview.DTOs.ReviewDTOs;

namespace BookReview.Services.IServices
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDTO>> GetAllReviewsAsync(int bookId); //Recension för en specifik bok
        Task<ReviewDTO?> GetReviewByIdAsync(int reviewId); //Recension baserat på ID
        Task<ReviewDTO?> CreateReviewToBookAsync(int bookId, CreateReviewDTO createReviewDTO); //Lägg till recension för en bok
        Task<bool> UpdateReviewAsync(int reviewId, UpdateReviewDTO updateReviewDTO); //Uppdatera recension
        Task<bool> DeleteReviewAsync(int reviewId); //Ta bort recension

       

    }
}
