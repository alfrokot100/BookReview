using System.ComponentModel.DataAnnotations;

namespace BookReview.DTOs.BookDTOs
{
    public class BookCreateDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        public string? Description { get; set; }
        public string Genre { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public string? CoverImageUrl { get; set; }
    }
}
