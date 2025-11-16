using BookReview.MVC.Models;
using BookReview.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace BookReview.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        private readonly HttpClient _httpClient;

        public BookController(BookService bookService, HttpClient httpClient)
        {
            _bookService = bookService;
            _httpClient = httpClient;
        }

        //Rteurnerar vyer
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
            if(book == null) { return NotFound(); }
            
            return View(book); // skickar modellen till Details.cshtml
        }

    }
}
