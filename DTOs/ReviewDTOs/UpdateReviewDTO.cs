using System.ComponentModel.DataAnnotations;

namespace BookReview.DTOs.ReviewDTOs
{
    public class UpdateReviewDTO
    {
        [Required]
        public int Rating { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;
    }
}
