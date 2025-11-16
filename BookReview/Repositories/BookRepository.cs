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
        public async Task<int> CreateBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }
        public async Task<bool> UpdateBookAsync(Book book)
        {
            var existingBook = await _context.Books.FindAsync(book.Id);
            if(existingBook == null) { return false; }

            _context.Entry(existingBook).CurrentValues.SetValues(book);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Book>> SearchBooksAsync(string query)
        {
            return await _context.Books
                .Where(b => b.Title.Contains(query) || b.Author.Contains(query))
                .ToListAsync();
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await GetBookByIdAsync(id);
            if(book == null) { return false; }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
        
    }
}
