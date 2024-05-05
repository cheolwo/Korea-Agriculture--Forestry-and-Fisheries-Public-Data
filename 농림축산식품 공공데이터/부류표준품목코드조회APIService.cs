using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;

namespace 食수집서버.Services
{
    public class 부류표준품목코드조회APIService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly string _apiUrl;
        private readonly string _apiName;

        public 부류표준품목코드조회APIService(HttpClient client, IConfiguration configuration)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _apiKey = configuration["농림축산Api:ApiKey"] ?? throw new ArgumentNullException(nameof(client));
            _apiUrl = configuration["농림축산Api:ApiUrl"] ?? throw new ArgumentNullException(nameof(client));
            _apiName = configuration["농림축산Api:ApiName:부류품목코드조회"] ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<string> GetCodeInfoAsync(string type, int startIndex, int endIndex,
            string lclassName = null, string lclassCode = null)
        {
            var requestUri = new UriBuilder(_apiUrl)
            {
                Path = $"/{type}/{_apiName}/{startIndex}/{endIndex}",
                Query = BuildQueryString(lclassName, lclassCode)
            };

            HttpResponseMessage response = await _client.GetAsync(requestUri.ToString());
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private string BuildQueryString(string lclassName, string lclassCode)
        {
            var queryBuilder = new QueryBuilder();

            if (!string.IsNullOrWhiteSpace(lclassName))
            {
                queryBuilder.Add("LCLASSNAME", lclassName);
            }
            if (!string.IsNullOrWhiteSpace(lclassCode))
            {
                queryBuilder.Add("LCLASSCODE", lclassCode);
            }

            return queryBuilder.ToString();
        }
    }
}
