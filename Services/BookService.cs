using BookReview.Data;
using BookReview.DTOs.BookDTOs;
using BookReview.Models;
using BookReview.Repositories.IRepositories;
using BookReview.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BookReview.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        public BookService(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }
        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            var books = await _bookRepo.GetAllBooksAsync();
            return books.Select(b => new BookDTO
            {
                Id = b.Id,
                Description = b.Description,
                Author = b.Author,
                Title = b.Title,
                Genre = b.Genre,
                PublishedYear = b.PublishedYear
            });
        }

        public async Task<BookDTO?> GetBookByIdAsync(int id)
        {
            var books = await _bookRepo.GetBookByIdAsync(id);
            if(books == null) { return null; }

            return new BookDTO
            {
                Id = books.Id,
                Description = books.Description,
                Author = books.Author,
                Title = books.Title,
                Genre = books.Genre,
                PublishedYear = books.PublishedYear
            };
        }
        public async Task<BookDTO> CreateBookAsync(BookCreateDTO dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Description = dto.Description,
                Author = dto.Author,
                Genre = dto.Genre
            };
            await _bookRepo.CreateBookAsync(book);
            await _bookRepo.SaveChangesAsync();

            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Genre = book.Genre
            };
        }

        public async Task<bool> UpdateBookAsync(int id, BookUpdateDTO dto)
        {
            var book = await _bookRepo.GetBookByIdAsync(dto.Id);
            if(book == null) { return false; }

            book.Title = dto.Title;
            book.Description = dto.Description;
            book.Author = dto.Author;
            book.Genre = dto.Genre;

            await _bookRepo.UpdateBookAsync(book);
            return await _bookRepo.SaveChangesAsync();
        }
        public async Task<bool> DeleteBookAsync(int id)
        {
            await _bookRepo.DeleteBookAsync(id);
            return await _bookRepo.SaveChangesAsync();
        }
    }
}
