using BookReview.Models;
using Microsoft.EntityFrameworkCore;

namespace BookReview.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {}
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
    }
    //Seedat data här lite senare

    
}
