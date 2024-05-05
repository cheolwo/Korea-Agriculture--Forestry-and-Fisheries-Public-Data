using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

class Program
{
    static async Task Main(string[] args)
    {
        // HttpClient 객체 생성
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // 기본 URL
                string baseUrl = "http://openapi.epis.or.kr/openapi/service/CodeListService/getSmallPrdlstCodeList";

                // 쿼리 파라미터 설정
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["LCLASSNAME"] = "우유및유제품";
                query["LCLASSCODE"] = "46";
                query["MCLASSNAME"] = "생우유";
                query["MCLASSCODE"] = "4601";
                string queryString = query.ToString();

                // 전체 URL 조합
                string url = $"{baseUrl}?{queryString}";

                // HTTP GET 요청 실행
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // 상태 코드 200-299가 아니면 예외 발생

                // 응답 본문 읽기
                string responseBody = await response.Content.ReadAsStringAsync();

                // 결과 콘솔에 출력
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                // 오류 처리
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
