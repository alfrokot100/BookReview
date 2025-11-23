using Microsoft.AspNetCore.Mvc;
using BookReview.MVC.Services;
using BookReview.Models;
using System.Threading.Tasks;

namespace BookReview.MVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<IActionResult> Index()
        {
            var reviewList = await _reviewService.GetReviewsAsync();
            return View(reviewList);
        }

        public IActionResult Create(int bookId)
        {
            var vm = new ReviewViewModel
            {
                BookId_FK = bookId
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewViewModel newReview)
        {
            if (!ModelState.IsValid)
            {
                return View(newReview);
            }

            var success = await _reviewService.CreateReviewAsync(newReview);

            if (success)
            {
                return RedirectToAction("Details", "Book", new { id = newReview.BookId_FK });
            }

            ModelState.AddModelError(string.Empty, "Could not save the review.");
            return View(newReview);
        }
    }
}