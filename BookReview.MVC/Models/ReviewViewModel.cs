using System.ComponentModel.DataAnnotations;

namespace BookReview.Models 
{
    public class ReviewViewModel
    {
        public int BookId_FK { get; set; }

        [Display(Name = "Ditt namn")]
        [Required(ErrorMessage = "Du måste ange ditt namn")]
        public string ReviewerName { get; set; } = string.Empty;

        [Display(Name = "Betyg (1-5)")]
        [Required(ErrorMessage = "Du måste ange ett betyg")]
        [Range(1, 5, ErrorMessage = "Betyget måste vara mellan 1 och 5")]
        public int Rating { get; set; }

        [Display(Name = "Din recension")]
        [Required(ErrorMessage = "Du måste skriva en recension")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; } = string.Empty;
    }
}