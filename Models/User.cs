namespace BookReview.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Relationer
        public ICollection<Review>? Reviews { get; set; }
    }
}
