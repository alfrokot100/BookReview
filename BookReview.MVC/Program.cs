using BookReview.MVC.Services;

namespace BookReview.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Lägg till CORS här
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

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

			builder.Services.AddHttpClient<AiService>(client =>
			{
				client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
			});

            //builder.Services.AddSingleton<OpenAiService>();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthorization();

            var app = builder.Build();

            app.UseCors("AllowAll");


            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Visa detaljerade fel
            }
            else
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
