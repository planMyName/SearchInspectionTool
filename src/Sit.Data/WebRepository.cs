using Sit.Data.Abstractions;

namespace Sit.Data
{
    public class WebRepository : IWebRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WebRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetContentFrom(string location)
        {
            using var client = _httpClientFactory.CreateClient($"Client-{location}");
            var result = await client.GetAsync(new Uri(location));
            var content = await result.Content.ReadAsStringAsync();
            return content;
        }
    }
}