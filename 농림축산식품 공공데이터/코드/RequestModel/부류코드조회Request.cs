using MediatR;

namespace 농림축산식품_공공데이터.코드.RequestModel
{
    /// <summary>
    /// 부류표준품목코드조회Request is used to configure and send requests to the category standard product code API.
    /// Properties:
    /// - API_KEY: Essential and immutable, set during instantiation.
    /// - TYPE: Configurable file type, default is XML, mutable.
    /// - API_URL: Specific API service URL part, immutable.
    /// - START_INDEX and END_INDEX: Configurable indices for API pagination, mutable.
    /// - LCLASSNAME and LCLASSCODE: Optional, mutable for querying specific categories.
    /// </summary>
    public class 부류코드조회Request : IRequest<Unit>
    {
        public string API_KEY { get; }  // API key is provided once during instantiation.
        public string TYPE { get; set; } = "xml";  // Default request file type, can be changed if necessary.
        public string API_URL { get; } = "Grid_20220823000000000629_1";  // Specific part of the service URL, immutable.
        public string START_INDEX { get; set; } = "1";  // Starting index for the API request, mutable.
        public string END_INDEX { get; set; } = "5";  // Ending index for the API request, mutable.
        public string? LCLASSNAME { get; set; }  // Optional: Class name for querying.
        public string? LCLASSCODE { get; set; }  // Optional: Class code for querying.

        /// <summary>
        /// Constructor for 부류표준품목코드조회Request requiring an API key.
        /// </summary>
        /// <param name="apiKey">The API key to be used for the request, must be securely stored and passed.</param>
        public 부류코드조회Request(string apiKey)
        {
            API_KEY = apiKey;
        }
    }
}
