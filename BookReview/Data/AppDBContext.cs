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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var bookEntity = modelBuilder.Entity<Book>();
            var reviewEntity = modelBuilder.Entity<Review>();
            var userEntity = modelBuilder.Entity<User>();

            bookEntity.HasData(
                new Book 
                {
                    Id = 1,
                    Title = "Den osynliga staden",
                    Author = "Italo Calvino",
                    Genre = "Fiktion",
                    Description = "En poetisk samling av berättelser om tänkta städer.",
                    PublishedYear = 1972
                },

                new Book 
                {
                    Id = 2,
                    Title = "Den eviga striden",
                    Author = "Stieg Larsson",
                    Genre = "Thriller",
                    Description = "Första delen i Millennium-serien.",
                    PublishedYear = 2005
                }
             );

            reviewEntity.HasData(
                new Review 
                {
                    Id = 1,
                    ReviewerName = "Alice Andersson",
                    Rating = 5,
                    Text = "Otroligt gripande bok – kunde inte sluta läsa!",
                    CreatedDate = new DateTime(2025, 10, 10),
                    BookId_FK = 1
                },

                new Review 
                {
                    Id = 2,
                    ReviewerName = "Björn Berg",
                    Rating = 4,
                    Text = "Riktigt spännande, men lite förutsägbar på slutet.",
                    CreatedDate = new DateTime(2025,10,10),
                    BookId_FK = 2
                }
                );

            userEntity.HasData(
                new User 
                {
                    Id = 1,
                    Name = "Vicke Andersson",
                    Email = "alice@example.com",
                    PasswordHash = "hash123", //Testdata
                    Role = "Admin",
                    CreatedAt = new DateTime(2025, 10, 10)
                },
                new User 
                {
                    Id = 2,
                    Name = "Björn Berg",
                    Email = "bjorn@example.com",
                    PasswordHash = "hash456",
                    Role = "User",
                    CreatedAt = new DateTime(2025, 10, 10)
                },
                new User
                {
                    Id = 3,
                    Name = "Anders Hertig",
                    Email = "clara@example.com",
                    PasswordHash = "hash789",
                    Role = "User",
                    CreatedAt = new DateTime(2025, 10, 10)
                }

                );

        }


    }
}
