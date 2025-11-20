using BookReview.MVC.Models;
using BookReview.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookReview.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        // /Book?searchString=...
        public async Task<IActionResult> Index(string? searchString)
        {
            IEnumerable<BookViewModel> books;

            if (!string.IsNullOrEmpty(searchString))
            {
                books = await _bookService.SearchAsync(searchString);
            }
            else
            {
                books = await _bookService.GetAllAsync();
            }

            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }
    }
}
