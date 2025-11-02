namespace BookReview.DTOs.ReviewDTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public int BookId { get; set; } //osäker
    }
}
