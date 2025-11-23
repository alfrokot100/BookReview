using BookReview.Models;
using BookReview.MVC.Models;
using System.Collections.Generic;

namespace BookReview.MVC.ViewModels
{
    public class BookDetailsViewModel
    {
        public BookViewModel? Book { get; set; }
        public IEnumerable<ReviewViewModel>? Reviews { get; set; }

        public string? Description { get; set; }
        public string? Genre { get; set; }
        public int PublishedYear { get; set; }
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
    }
}