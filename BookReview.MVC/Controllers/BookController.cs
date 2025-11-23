using BookReview.MVC.Models;
using BookReview.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Collections.Generic; 
using System.Threading.Tasks; 
using BookReview.MVC.ViewModels; 
using BookReview.Models; 

namespace BookReview.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        private readonly HttpClient _httpClient;
        private readonly ReviewService _reviewService; // Nytt

        // Uppdatera konstruktorn för att inkludera ReviewService
        public BookController(BookService bookService, HttpClient httpClient, ReviewService reviewService)
        {
            _bookService = bookService;
            _httpClient = httpClient;
            _reviewService = reviewService; // Nytt
        }

        public async Task<IActionResult> Index(string? searchString)
        {
            IEnumerable<BookViewModel> books;

            if (!string.IsNullOrEmpty(searchString))
            {
                var response = await _httpClient.GetAsync($"https://localhost:7124/api/book/search?query={searchString}");
                if (response.IsSuccessStatusCode)
                {
                    books = await response.Content.ReadFromJsonAsync<IEnumerable<BookViewModel>>();
                }
                else
                {
                    books = new List<BookViewModel>();
                }
            }
            else
            {
                //Hämtar alla böcker via API
                var response = await _httpClient.GetAsync("https://localhost:7124/api/book");
                if (response.IsSuccessStatusCode)
                {
                    books = await response.Content.ReadFromJsonAsync<IEnumerable<BookViewModel>>();
                }
                else
                {
                    books = new List<BookViewModel>();
                }
            }

            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) { return NotFound(); }

            // 2. Hämta recensionerna - NY
            var reviews = await _reviewService.GetReviewsForBookAsync(id);

            // 3. Skapa ny Modell - NY
            var viewModel = new BookDetailsViewModel
            {
                Book = book,
                Reviews = reviews
            };

            // 4. Skicka den nya modellen till views - NY
            return View(viewModel); // skickar den nya modellen till Details.cshtml
        }

    }
}