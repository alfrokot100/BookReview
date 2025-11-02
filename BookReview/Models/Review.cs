namespace BookReview.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; } = string.Empty;
        public int Rating { get; set; }  // 1–5 stjärnor
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Foreign Key
        public int BookId_FK { get; set; }
        public Book? Book { get; set; }
    }
}
