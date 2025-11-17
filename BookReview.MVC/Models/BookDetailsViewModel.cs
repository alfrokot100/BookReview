using BookReview.Models;
using BookReview.MVC.Models;
using System.Collections.Generic;

namespace BookReview.MVC.ViewModels
{
    public class BookDetailsViewModel
    {
        public BookViewModel? Book { get; set; }
        public IEnumerable<ReviewViewModel>? Reviews { get; set; }
    }
}