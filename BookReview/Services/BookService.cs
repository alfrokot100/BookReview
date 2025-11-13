using BookReview.Data;
using BookReview.DTOs.BookDTOs;
using BookReview.Models;
using BookReview.Repositories.IRepositories;
using BookReview.Services.IServices;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

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
            var book = await _bookRepo.GetAllBooksAsync();
            return book.Select(b => new BookDTO
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
            var book = await _bookRepo.GetBookByIdAsync(id);
            if(book == null) { return null; }

            return new BookDTO
            {
                Id = book.Id,
                Description = book.Description,
                Author = book.Author,
                Title = book.Title,
                Genre = book.Genre,
                PublishedYear = book.PublishedYear
            };
        }
        public async Task<BookDTO> CreateBookAsync(BookCreateDTO dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Description = dto.Description,
                Author = dto.Author,
                Genre = dto.Genre,
                PublishedYear = dto.PublishedYear
            };
            await _bookRepo.CreateBookAsync(book);

            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Genre = book.Genre,
                PublishedYear = book.PublishedYear
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
            book.PublishedYear = dto.PublishedYear;

            return await _bookRepo.UpdateBookAsync(book);
        }

        public async Task<IEnumerable<BookDTO>> SearchBooksAsync(string query)
        {
            var books = await _bookRepo.SearchBooksAsync(query);

            return books.Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Description = b.Description,
                Genre = b.Genre,
                PublishedYear = b.PublishedYear
            });
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            return await _bookRepo.DeleteBookAsync(id);
        }
    }
}
