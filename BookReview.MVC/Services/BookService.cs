using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BookReview.MVC.Models;

namespace BookReview.MVC.Services
{
    public class BookService
    {
        private readonly HttpClient _http;

        public BookService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<IEnumerable<BookViewModel>>("api/book");
                return result ?? new List<BookViewModel>();
            }
            catch
            {
                return new List<BookViewModel>();
            }
        }

        public async Task<BookViewModel?> GetByIdAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<BookViewModel>($"api/book/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<BookViewModel>> SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<BookViewModel>();

            try
            {
                var encoded = System.Net.WebUtility.UrlEncode(query);
                var result = await _http.GetFromJsonAsync<IEnumerable<BookViewModel>>($"api/book/search?query={encoded}");
                return result ?? new List<BookViewModel>();
            }
            catch
            {
                return new List<BookViewModel>();
            }
        }
    }
}
