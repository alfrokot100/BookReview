using BookReview.DTOs.BookDTOs;
using BookReview.Models;

namespace BookReview.Repositories.IRepositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<int> CreateBookAsync(Book book);
        Task<bool> UpdateBookAsync(Book book);
        Task<IEnumerable<Book>> SearchBooksAsync(string query);
        Task<bool> DeleteBookAsync(int id);

    }
}
