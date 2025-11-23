using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookReview.Services
{
    public class OpenAIService
    {
        private readonly ChatClient _chatClient;

        public OpenAIService()
        {
            var endpoint = new Uri("https://bookai-demo.cognitiveservices.azure.com/");
            var deploymentName = "gpt-35-turbo";
            var apiKey = "49XlqgivQxz75SQV2Z2hMBHIfRjuIjtrX8g9axwbJTrpO5SQOd35JQQJ99BJACOGoghi";

            var azureClient = new AzureOpenAIClient(endpoint, new AzureKeyCredential(apiKey));
            _chatClient = azureClient.GetChatClient(deploymentName);
        }

        // Lagt till enkel felhantering (try/catch)
        public async Task<string> GenerateBookReviewAsync(string title, string description)
        {
            try
            {
                var messages = new List<ChatMessage>()
                {
                    new SystemChatMessage("Du är en hjälpsam bokrecensent."),
                    new UserChatMessage($"Skriv en recension för boken '{title}'. Beskrivning: {description}")
                };

                var requestOptions = new ChatCompletionOptions()
                {
                    MaxOutputTokenCount = 500,
                    Temperature = 1.0f,
                    TopP = 1.0f
                };

                var response = await _chatClient.CompleteChatAsync(messages, requestOptions);
                return response.Value.Content[0].Text;
            }
            catch (Exception ex)
            {
                return $"Ett fel uppstod vid AI-anropet: {ex.Message}";
            }
        }
    }
}
