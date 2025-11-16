// Du behöver inte denna "using" om du inte
// använder en separat BookService-klass
// using BookReview.MVC.Services; 

namespace BookReview.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ---------------------------------------------------
            // 1. ALLA SERVICES REGISTRERAS HÄR
            // ---------------------------------------------------

            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient<BookService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7124/");

            });
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            // LÄGG TILL DENNA FÖR ATT MATCHA LÄRARENS DEMO
            builder.Services.AddHttpClient("BookApi", client =>
            {
                // Hämta bas-URL:en från appsettings.json
                // Se till att "ApiBaseUrl" finns i din appsettings!
                client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
            });

            // ---------------------------------------------------
            // 2. APPLIKATIONEN BYGGS HÄR (EFTER SERVICES)
            // ---------------------------------------------------
            var app = builder.Build();


            // ---------------------------------------------------
            // 3. PIPELINE KONFIGURERAS HÄR
            // ---------------------------------------------------
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