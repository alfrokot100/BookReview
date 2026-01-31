using BookReview.Data;
using BookReview.DTOs.UserDTOs;
using BookReview.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReview.Services
{
    public class UserService
    {
        private readonly AppDBContext _context;

        public UserService(AppDBContext context)
        {
            _context = context;
        }

        //  ny användare
        public async Task<User> RegisterUserAsync(RegisterUserDTO dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.Password, 
                Role = "User",
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Logga in för användare
        public async Task<User?> LoginUserAsync(LoginUserDTO dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email && u.PasswordHash == dto.Password);

            return user;
        }
    }
}
