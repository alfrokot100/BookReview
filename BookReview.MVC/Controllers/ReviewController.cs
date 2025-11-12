using Microsoft.AspNetCore.Mvc;
using BookReview.MVC.Services;
using BookReview.MVC.Models;
using BookReview.Models;

namespace BookReview.MVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly HttpClient _client;

        public ReviewController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("BookApi");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("reviews");

            if (!response.IsSuccessStatusCode)
            {
                return View(new List<ReviewViewModel>());
            }

            var reviewList = await response.Content.ReadFromJsonAsync<IEnumerable<ReviewViewModel>>();

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

        // POST: Review/Create
        [HttpPost]
        public async Task<IActionResult> Create(ReviewViewModel newReview)
        {
            if (!ModelState.IsValid)
            {
                return View(newReview);
            }         

            // https://localhost:xxxx/api/reviews
            var response = await _client.PostAsJsonAsync("reviews", newReview);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", "Book", new { id = newReview.BookId_FK });
            }

            // Om något gick fel med API-anropet
            ModelState.AddModelError(string.Empty, "Could not save the review.");
            return View(newReview);
        }
    }
}
