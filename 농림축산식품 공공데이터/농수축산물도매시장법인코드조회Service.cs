using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace 농림축산식품_공공데이터
{
    public interface I공공데이터APIService
    {
        Task<string> GetDataAsync(string apiKey, string type, int startIndex, int endIndex, string? additionalParam = null);
        Task<int> GetTotalCountAsync(string apiKey, string type);
        Task<string> GetAllDataAsync(string apiKey, string type);
        Task<string> GetPagedDataAsync(string apiKey, string type, int pageSize, string? additionalParam = null);
    }

    public class 농수축산물도매시장법인코드조회APIService : I공공데이터APIService
    {
        private readonly HttpClient _httpClient;
        private string? _apiUrl = null;

        public 농수축산물도매시장법인코드조회APIService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetDataAsync(string apiKey, string type, int startIndex, int endIndex, string? additionalParam = null)
        {
            if (_apiUrl == null)
            {
                _apiUrl = $"http://211.237.50.150:7080/openapi/sample/{apiKey}/{type}/Grid_20141221000000000123_1";
            }

            string requestUri = $"{_apiUrl}/{startIndex}/{endIndex}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                throw new ApplicationException("도매시장법인코드 조회 중 오류 발생", e);
            }
        }

        public async Task<int> GetTotalCountAsync(string apiKey, string type)
        {
            string apiUrl = $"{_apiUrl}/1/1";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                int totalCount = int.Parse(result.Substring(result.IndexOf("<totalCnt>") + "<totalCnt>".Length, result.IndexOf("</totalCnt>") - result.IndexOf("<totalCnt>") - "<totalCnt>".Length));
                return totalCount;
            }
            catch (HttpRequestException e)
            {
                throw new ApplicationException("전체 Total 조회 중 오류 발생", e);
            }
        }

        public async Task<string> GetAllDataAsync(string apiKey, string type)
        {
            int totalCount = await GetTotalCountAsync(apiKey, type);
            return await GetDataAsync(apiKey, type, 1, totalCount);
        }

        public async Task<string> GetPagedDataAsync(string apiKey, string type, int pageSize, string? additionalParam = null)
        {
            int totalCount = await GetTotalCountAsync(apiKey, type);
            List<string> dataPages = new List<string>();

            for (int startIndex = 1; startIndex <= totalCount; startIndex += pageSize)
            {
                int endIndex = Math.Min(startIndex + pageSize - 1, totalCount);
                string data = await GetDataAsync(apiKey, type, startIndex, endIndex, additionalParam);
                dataPages.Add(data);
            }

            return string.Join("\n", dataPages);
        }
    }
}
