using BookReview.Models;
using BookReview.MVC.Models;
using System.Text.Json;

namespace BookReview.MVC.Services
{
    public class BookService
    {
        private readonly HttpClient _http;

        public BookService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync()
        {
			//var response = await _http.GetAsync("https://localhost:7124/api/book"); // API-url
			//response.EnsureSuccessStatusCode();

			//var json = await response.Content.ReadAsStringAsync();
			//return JsonSerializer.Deserialize<IEnumerable<BookViewModel>>(json, new JsonSerializerOptions
			//{
			//    PropertyNameCaseInsensitive = true
			//})!;

			var books = await _http.GetFromJsonAsync<IEnumerable<BookViewModel>>("book");
			return books ?? new List<BookViewModel>();
		}

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            var book = await _http.GetFromJsonAsync<BookViewModel>($"book/{id}");
            return book;
        }

    }
}
