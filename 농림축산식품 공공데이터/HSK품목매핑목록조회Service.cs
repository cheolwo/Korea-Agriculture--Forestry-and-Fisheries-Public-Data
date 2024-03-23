namespace HSKItemMapping
{
    public class HSK품목매핑목록조회Service
    {
        private readonly HttpClient _client;

        public HSK품목매핑목록조회Service(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<string> GetHSKItemMappingAsync(string apiKey, int startIndex, int endIndex, string categoryCode, string productCode)
        {
            string apiUrl = "http://211.237.50.150:7080/openapi/sample/xml/Grid_20221207000000000652_1/1/5";
            string queryData = $"?API_KEY={apiKey}&TYPE=json&START_INDEX={startIndex}&END_INDEX={endIndex}&CATEGORY_CODE={categoryCode}&STD_PRDLST_CODE={productCode}";
            string requestUri = apiUrl + queryData;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode(); // 상태 코드가 200-299인지 확인
                return await response.Content.ReadAsStringAsync(); // 응답 본문을 문자열로 반환
            }
            catch (HttpRequestException e)
            {
                throw new ApplicationException("HSK Item Mapping 조회 중 오류 발생", e);
            }
        }
    }
}
