using BookReview.DTOs.ReviewDTOs;
using BookReview.Models;

namespace BookReview.Repositories.IRepositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync(int bookId); //Recension för en specifik bok
        Task<Review?> GetReviewByIdAsync(int bookId); //Recension baserat på ID
        Task CreateReviewAsync(Review review); //Lägg till recension för en bok
        void UpdateReviewAsync(Review review); //Uppdatera recension
        Task<bool> DeleteReviewAsync(int reviewId); //Ta bort recension
        Task<bool> SaveChangesAsync(); //Spara ändringar
    }
}
