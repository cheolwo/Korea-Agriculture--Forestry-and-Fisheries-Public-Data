namespace 농림축산식품_공공데이터
{
    public class 농수축산물도매시장법인코드조회APIService
    {
        private readonly HttpClient _httpClient;
        private string apiUrl = "http://211.237.50.150:7080/openapi/sample/xml/Grid_20141221000000000123_1/1/5";
        public 농수축산물도매시장법인코드조회APIService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetWholesaleMarketCorpCodeAsync(string apiKey, string type, int startIndex, int endIndex, string whsalMrktCd = null, string whsalMrktNm = null, string cprCd = null, string cprNm = null)
        {
            apiUrl = $"http://211.237.50.150:7080/openapi/{apiKey}/{type}/Grid_20141221000000000123_1/{startIndex}/{endIndex}";

            string requestUri = apiUrl;

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
                response.EnsureSuccessStatusCode(); // 상태 코드가 200-299인지 확인
                return await response.Content.ReadAsStringAsync(); // 응답 본문을 문자열로 반환
            }
            catch (HttpRequestException e)
            {
                throw new ApplicationException("도매시장법인코드 조회 중 오류 발생", e);
            }
        }
        public async Task<int> GetTotalCountAsync(string apiKey, string type)
        {
            apiUrl = $"http://211.237.50.150:7080/openapi/{apiKey}/{type}/Grid_20141221000000000123_1/1/1";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode(); // 상태 코드가 200-299인지 확인

                string result = await response.Content.ReadAsStringAsync(); // 응답 본문을 문자열로 반환
                // XML 또는 JSON 파싱하여 totalCnt 값을 가져오는 로직 구현
                // 예를 들어, XML일 경우 XmlDocument 또는 XDocument를 사용하여 파싱할 수 있습니다.

                // 여기서는 임시로 문자열 처리를 사용하겠습니다.
                int totalCount = int.Parse(result.Substring(result.IndexOf("<totalCnt>") + "<totalCnt>".Length, result.IndexOf("</totalCnt>") - result.IndexOf("<totalCnt>") - "<totalCnt>".Length));
                return totalCount;

            }
            catch (HttpRequestException e)
            {
                throw new ApplicationException("전체 Total 조회 중 오류 발생", e);   
            }
        }
    }
}
