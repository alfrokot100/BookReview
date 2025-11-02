using BookReview.Data;
using BookReview.DTOs.BookDTOs;
using BookReview.Models;
using BookReview.Services;
using BookReview.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookReview.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if(book == null) { return NotFound(); }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCreateDTO dto)
        {
            var id = await _bookService.CreateBookAsync(dto);
            //var createdBook = await _bookService.GetBookByIdAsync(id);
            return CreatedAtAction(nameof(Get), new { id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] BookUpdateDTO dto)
        {
            if (id != dto.Id) { return BadRequest("ID mismatch"); }
            var success = await _bookService.UpdateBookAsync(id, dto);
            if (!success) return NotFound();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _bookService.DeleteBookAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }

    }
}
