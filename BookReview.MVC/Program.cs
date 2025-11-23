using BookReview.MVC.Services;
using BookReview.Services;

namespace BookReview.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
          
            // Lägg till services här
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient<BookService>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
            }); // <-- flyttad hit

            builder.Services.AddHttpClient<ReviewService>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
            });

            builder.Services.AddSingleton<OpenAIService>();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
