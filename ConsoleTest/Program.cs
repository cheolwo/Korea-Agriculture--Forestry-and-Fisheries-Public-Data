using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        // API 요청 URL
        string apiUrl = "http://211.237.50.150:7080/openapi/sample/xml/Grid_20221207000000000652_1/1/5";

        // 쿼리 데이터 구성
        string queryData = "?API_KEY=b7d7ea37f4a78231390d208fedd0a2ea1d78c967819a642885c664b391b1c0b6"
                         + "&TYPE=json"
                         + "&START_INDEX=1"
                         + "&END_INDEX=5"
        + "&CATGORY_CODE=61"
        + "&STD_PRDLST_CODE=6112";
        //+ "&CATGORY_NM=YOUR_CATEGORY_NAME_HERE"
        //+ "&STD_PRDLST_NM=YOUR_PRODUCT_NAME_HERE";

        // 최종 요청 URL 구성
        string requestUri = apiUrl + queryData;

        try
        {
            // HTTP GET 요청 실행
            HttpResponseMessage response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode(); // 상태 코드가 200-299인지 확인

            // 응답 본문을 문자열로 받음
            string responseBody = await response.Content.ReadAsStringAsync();

            // 응답 출력
            Console.WriteLine("Received Response:");
            Console.WriteLine(responseBody);

            // 필요에 따라 XML 또는 JSON 데이터 처리
        }
        catch (HttpRequestException e)
        {
            // HTTP 요청 중 에러 발생 시 처리
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
    }
}
