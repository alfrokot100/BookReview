namespace BookReview.DTOs.BookDTOs
{
    public class BookUpdateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Genre { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public string? CoverImageUrl { get; set; }
    }
}
