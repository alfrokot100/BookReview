using System.Threading.Tasks;
using BookReview.Models;

namespace BookReview.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
