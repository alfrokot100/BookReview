using BookReview.DTOs.AIDTOs;
using BookReview.DTOs.ReviewDTOs;  // För CreateReviewDTO
using BookReview.Services;
using BookReview.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookReview.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : ControllerBase
    {
        private readonly OpenAIService _openAIService;
        private readonly IReviewService _reviewService;

        public AIController(OpenAIService openAIService, IReviewService reviewService)
        {
            _openAIService = openAIService;
            _reviewService = reviewService;
        }

        [HttpPost("review")]
        public async Task<IActionResult> GenerateReview([FromBody] BookRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.Description))
                return BadRequest("Title och Description måste fyllas i.");

            try
            {
                // 1️⃣ Hämta AI-text
                var aiText = await _openAIService.GenerateBookReviewAsync(request.Title, request.Description);

                // 2️⃣ Skapa CreateReviewDTO
                var createReviewDTO = new CreateReviewDTO
                {
                    ReviewerName = "AI-Recensent",
                    Rating = 5,
                    Text = aiText
                };

                int bookId = 1; // ✏️ Tillfälligt: här bör du hämta BookId från frontend

                // 3️⃣ Spara recension via service
                var savedReview = await _reviewService.CreateReviewToBookAsync(bookId, createReviewDTO);

                // 4️⃣ Returnera bekräftelse
                return Ok(new
                {
                    Message = "AI-recension skapad och sparad i databasen!",
                    ReviewId = savedReview?.Id,
                    AIText = aiText
                });
            }
            catch (Exception ex)
            {
                //  Felhantering: returnera ett tydligt felmeddelande
                return BadRequest(new
                {
                    Message = "Kunde inte generera AI-recension just nu.",
                    Error = ex.Message
                });
            }
        }
    }
}
