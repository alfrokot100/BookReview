using BookReview.DTOs.AIDTOs;
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
        

        public AIController(OpenAIService openAIService)
        {
            _openAIService = openAIService;
            
        }

        [HttpPost("review")]
        public async Task<IActionResult> GenerateReview([FromBody] BookRequest request)
        {
            //  Kontrollera att request är korrekt
            if (request == null || string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.Description))
                return BadRequest("Title, Description och BookId måste fyllas i."); // Sami ändring: BookId check

            try
            {
                // Generera AI-text baserat på titel och beskrivning
                var aiText = await _openAIService.GenerateBookReviewAsync(request.Title, request.Description);

               

                return Ok(new
                {
                    AIText = aiText,
                    
                });
            }
            catch (Exception ex)
            {
                //  Felhantering: returnera tydligt felmeddelande
                return BadRequest(new
                {
                    Message = "Kunde inte generera AI-recension just nu.",
                    Error = ex.Message
                });
            }
        }
    }
}
