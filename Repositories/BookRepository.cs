using BookReview.Data;
using BookReview.DTOs.BookDTOs;
using BookReview.Models;
using BookReview.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BookReview.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDBContext _context;
        public BookRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var books = await _context.Books
                .Include(b => b.Reviews)
                .ToListAsync();
            return books;
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            var books = await _context.Books
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(b => b.Id == id);
            return books;
        }
        public async Task CreateBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }
        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await GetBookByIdAsync(id);
            if(book == null)
            {
                _context.Books.Remove(book);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
