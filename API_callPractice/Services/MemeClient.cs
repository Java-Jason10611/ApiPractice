using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace API_callPractice.Services
{
    public class MemeClient : IMemeClient
    {
        private readonly HttpClient _client;
        public MemeClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<MemeResponse> GetMemeImages(string theEnd = "get_memes")
        {
            var results = await _client.GetAsync($"/{theEnd}");

            if (results.IsSuccessStatusCode)
            {
                var stringContent = await results.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                var obj = JsonSerializer.Deserialize<MemeResponse>(stringContent, options);
                return obj;

            }
            else 
            {
                throw new HttpRequestException("nothing 4(00) you");
            }
        }
    }
}
