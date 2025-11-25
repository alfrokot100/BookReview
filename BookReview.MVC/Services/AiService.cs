using Azure;
using BookReview.MVC.Models;
using System.Reflection;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;


namespace BookReview.MVC.Services
{
	public class AiService
	{
		private readonly HttpClient _httpClient;

        public AiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

		public async Task<string?> GenerateReviewAsync(AiViewModel model)
		{

            try
            {
                var json = JsonSerializer.Serialize(new
                {
                    title = model.Title,
                    description = model.Description
                });

                Console.WriteLine($"Skickar till: api/AI/review");
                Console.WriteLine($"JSON: {json}");

                var response = await _httpClient.PostAsync(
                    "AI/review",
                    new StringContent(json, Encoding.UTF8, "application/json"));

                Console.WriteLine($"Statuskod: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Fel: {errorContent}");
                    return $"HTTP {response.StatusCode}: {errorContent}";
                }

                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Resultat: {result}");

                var parsed = JsonDocument.Parse(result);
                return parsed.RootElement.GetProperty("aiText").GetString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return $"Exception: {ex.Message}";
            }

        }
	}
}
