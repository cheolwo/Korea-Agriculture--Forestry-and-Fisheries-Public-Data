using Microsoft.Extensions.Configuration;

namespace 食수집서버.Services
{
    public class 부류표준품목코드조회APIService
    {
        private readonly HttpClient _client;
        private string ApiKey { get; set; }
        private string ApiUrl { get; set; }

        public 부류표준품목코드조회APIService(HttpClient client, IConfiguration configuration)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            ApiKey = configuration["농림축산Api:ApiKey"] ?? throw new ArgumentNullException(nameof(client));
            ApiUrl = configuration["농림축산Api:ApiUrl"] ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<string> GetLClassCodeAsync(string type, int startIndex, int endIndex, 
            string lclassName = null, string lclassCode = null)
        {   
            string requestUri = $"{ApiUrl}{ApiKey}/{type}/Grid_20220823000000000629_1/{startIndex}/{endIndex}";

            if (!string.IsNullOrWhiteSpace(lclassName))
            {
                requestUri += $"&LCLASSNAME={Uri.EscapeDataString(lclassName)}";
            }
            if (!string.IsNullOrWhiteSpace(lclassCode))
            {
                requestUri += $"&LCLASSCODE={Uri.EscapeDataString(lclassCode)}";
            }

            HttpResponseMessage response = await _client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
