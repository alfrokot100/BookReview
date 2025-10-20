using BookReview.DTOs.ReviewDTOs;
using BookReview.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BookReview.Controllers
{
    [ApiController]
    [Route("api")] 
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET /api/books/5/reviews - Hämta alla recensioner för en specifik bok
        [HttpGet("books/{bookId}/reviews")]
        public async Task<IActionResult> GetAllReviewsForBook(int bookId)
        {
            var reviews = await _reviewService.GetAllReviewsAsync(bookId);
            return Ok(reviews);
        }


        // GET /api/reviews/101 - Hämta en enskild recension med dess eget ID
        [HttpGet("reviews/{reviewId}")] 
        public async Task<IActionResult> GetReviewById(int reviewId)
        {
            var review = await _reviewService.GetReviewByIdAsync(reviewId);
            if (review == null)
            {
                return NotFound(); 
            }
            return Ok(review);
        }

        // POST /api/books/5/reviews - Skapa en ny recension för en bok 
        [HttpPost("books/{bookId}/reviews")]
        public async Task<IActionResult> CreateReview(int bookId, [FromBody] CreateReviewDTO createDto)
        {
            var newReview = await _reviewService.CreateReviewToBookAsync(bookId, createDto);
            if (newReview == null)
            {
                return NotFound($"Kunde inte hitta bok med ID {bookId}.");
            }

            // Returnerar 201 Created. Inkluderar en länk till den nya recensionen i headern.
            return CreatedAtAction(nameof(GetReviewById), new { reviewId = newReview.Id }, newReview);
        }

        // PUT /api/reviews/101 - Uppdatera en befintlig recension 
        [HttpPut("reviews/{reviewId}")]
        public async Task<IActionResult> UpdateReview(int reviewId, [FromBody] UpdateReviewDTO updateDto)
        {
            var success = await _reviewService.UpdateReviewAsync(reviewId, updateDto);
            if (!success)
            {
                return NotFound();
            }
            return NoContent(); 
        }

        // DELETE /api/reviews/101 - Ta bort en recension 
        [HttpDelete("reviews/{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var success = await _reviewService.DeleteReviewAsync(reviewId);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}