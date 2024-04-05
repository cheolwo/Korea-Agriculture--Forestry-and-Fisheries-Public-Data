using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace 농림축산식품_공공데이터
{
    public class 가락시장품목코드조회Service
    {
        private readonly HttpClient _httpClient;

        public 가락시장품목코드조회Service(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetGarrakItemCodeAsync(string apiKey, string type, 
            string apiUrl, int startIndex, int endIndex, string garrakName,
            string stanCode, string sclassCode, string garrakCode)
        {
            string requestUri = $"{apiUrl}?API_KEY={apiKey}&TYPE={type}" +
                $"&START_INDEX={startIndex}&END_INDEX={endIndex}" +
                $"&GARRAK_NAME={garrakName}&STAN_CODE={stanCode}" +
                $"&SCLASSCODE={sclassCode}&GARRAK_CODE={garrakCode}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode(); // Ensure the response is successful.
                return await response.Content.ReadAsStringAsync(); // Read response content as string.
            }
            catch (HttpRequestException e)
            {
                throw new ApplicationException("가락시장품목코드 조회 중 오류 발생", e);
            }
        }
    }
}
