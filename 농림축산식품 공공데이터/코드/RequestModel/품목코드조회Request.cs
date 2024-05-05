using MediatR;

namespace 농림축산식품_공공데이터.코드.RequestModel
{
    /// <summary>
    /// 표준품목코드조회Request is designed to handle requests for the standard product codes of agricultural, forestry, and fisheries products.
    /// It uses several optional parameters to filter results and requires MediatR for handling.
    /// </summary>
    internal class 표준품목코드조회Request : IRequest<Unit>
    {
        public string API_KEY { get; set; }  // The API key required for the request
        public string TYPE { get; set; } = "xml";  // The file type of the response, defaults to XML
        public string API_URL { get; } = "Grid_20141221000000000120_1";  // The API URL, immutable as it is set to a default value
        public int START_INDEX { get; set; } = 1;  // The starting index for data retrieval
        public int END_INDEX { get; set; } = 5;  // The ending index for data retrieval
        public string? CATGORY_CD { get; set; }  // Optional: Category code for querying specific categories
        public string? CATGORY_NM { get; set; }  // Optional: Category name for querying
        public string? PRDLST_CD { get; set; }  // Optional: Product code for querying specific products
        public string? PRDLST_NM { get; set; }  // Optional: Product name for querying
        public string? SPCIES_CD { get; set; }  // Optional: Species code for querying specific species
        public string? SPCIES_NM { get; set; }  // Optional: Species name for querying

        /// <summary>
        /// Constructor for 표준품목코드조회Request allows setting the initial essential parameters.
        /// </summary>
        /// <param name="apiKey">The API key to be used for request authorization.</param>
        public 표준품목코드조회Request(string apiKey)
        {
            API_KEY = apiKey;  // Setting the API key during instantiation
        }
    }
}
