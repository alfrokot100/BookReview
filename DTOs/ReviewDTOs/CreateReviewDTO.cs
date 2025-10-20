using System.ComponentModel.DataAnnotations;

namespace BookReview.DTOs.ReviewDTOs
{
    public class CreateReviewDTO
    {
        [Required]
        public string ReviewerName { get; set; } = string.Empty;

        [Required]
        public int Rating { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;
    }
}
