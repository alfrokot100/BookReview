using BookReview.Data;
using BookReview.Repositories.IRepositories;
using BookReview.Repositories;
using BookReview.Services;
using BookReview.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookReview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ===== Configuration =====
            var configuration = builder.Configuration;

            // ===== OpenAI service (reads config via IConfiguration in its ctor) =====
            builder.Services.AddSingleton<OpenAIService>();

            // ===== Controllers & Swagger =====
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ===== Database =====
            builder.Services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            // ===== Repositories & Services =====
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookService, BookService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<UserService>();

            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IReviewService, ReviewService>();

            // ===== (Optional) Authentication setup if you use JWT =====
            var jwtKey = configuration["Jwt:Key"];
            if (!string.IsNullOrEmpty(jwtKey))
            {
                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                        };
                    });
            }

            var app = builder.Build();

            // ===== Middleware pipeline =====
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Authentication must come before Authorization
            if (!string.IsNullOrEmpty(jwtKey))
            {
                app.UseAuthentication();
            }
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
