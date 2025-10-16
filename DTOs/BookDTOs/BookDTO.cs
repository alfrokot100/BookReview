namespace BookReview.DTOs.BookDTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int PublishedYear { get; set; }
        public string? CoverImageUrl { get; set; }
    }
}
