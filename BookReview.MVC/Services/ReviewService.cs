using BookReview.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BookReview.MVC.Services
{
    public class ReviewService
    {
        private readonly HttpClient _httpClient;

        public ReviewService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ReviewViewModel>> GetReviewsAsync()
        {
            var response = await _httpClient.GetAsync("reviews");

            if (!response.IsSuccessStatusCode)
            {
                return new List<ReviewViewModel>();
            }

            return await response.Content.ReadFromJsonAsync<IEnumerable<ReviewViewModel>>();
        }

        public async Task<bool> CreateReviewAsync(ReviewViewModel newReview)
        {
            string apiUrl = $"books/{newReview.BookId_FK}/reviews";

            var response = await _httpClient.PostAsJsonAsync(apiUrl, newReview);

            return response.IsSuccessStatusCode;
        }

        // NY METOD för att hämta recensioner för EN bok
        public async Task<IEnumerable<ReviewViewModel>> GetReviewsForBookAsync(int bookId)
        {
            // Vi bygger den korrekta URL:en från din Swagger-bild
            string apiUrl = $"books/{bookId}/reviews";

            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                // Om boken inte har recensioner (eller vid fel), returnera en tom lista.
                return new List<ReviewViewModel>();
            }

            return await response.Content.ReadFromJsonAsync<IEnumerable<ReviewViewModel>>();
        }
    }
}