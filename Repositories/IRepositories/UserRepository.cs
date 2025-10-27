using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookReview.Data;
using BookReview.Models;
using BookReview.Repositories.IRepositories;

namespace BookReview.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;

        public UserRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            // OBS: vi kör inte SaveChanges här — det görs i SaveChangesAsync för samma mönster som BookRepository
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
