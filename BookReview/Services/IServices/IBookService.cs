using BookReview.DTOs.BookDTOs;

namespace BookReview.Services.IServices
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<BookDTO> CreateBookAsync(BookCreateDTO dto);
        Task<bool> UpdateBookAsync(int id, BookUpdateDTO dto);
        Task<bool> DeleteBookAsync(int id);
        Task<IEnumerable<BookDTO>> SearchBooksAsync(string query);

    }
}
