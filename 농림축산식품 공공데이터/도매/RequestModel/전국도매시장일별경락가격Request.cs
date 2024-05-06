using MediatR;

namespace 농림축산식품_공공데이터.코드.RequestModel
{
    /// <summary>
    /// 전국도매시장일별경락가격Request is used to configure and send requests to the wholesale market daily auction price API.
    /// Properties:
    /// - API_KEY: Essential and immutable, set during instantiation.
    /// - TYPE: Configurable file type, default is XML, mutable.
    /// - API_URL: Specific API service URL part, immutable.
    /// - START_INDEX and END_INDEX: Configurable indices for API pagination, mutable.
    /// - Other optional and required parameters for querying specific market and product details.
    /// </summary>
    public class 전국도매시장일별경락가격Request : IRequest<Unit>
    {
        public string API_KEY { get; }  // API key is provided once during instantiation.
        public string TYPE { get; set; } = "xml";  // Default request file type, can be changed if necessary.
        public string API_URL { get; } = "Grid_20141119000000000012_1";  // Specific part of the service URL, immutable.
        public string START_INDEX { get; set; } = "1";  // Starting index for the API request, mutable.
        public string END_INDEX { get; set; } = "5";  // Ending index for the API request, mutable.
        public string AUCNG_DE { get; set; }  // Required: Auction date.
        public string? PBLMNG_WHSAL_MRKT_NM { get; set; }  // Optional: Public wholesale market name.
        public string? PBLMNG_WHSAL_MRKT_CD { get; set; }  // Optional: Public wholesale market code.
        public string? CPR_NM { get; set; }  // Optional: Corporation name within the wholesale market.
        public string? CPR_CD { get; set; }  // Optional: Corporation code within the wholesale market.
        public string? PRDLST_NM { get; set; }  // Optional: Product name.
        public string? PRDLST_CD { get; set; }  // Optional: Product code.
        public string? SPCIES_NM { get; set; }  // Optional: Species name.
        public string? SPCIES_CD { get; set; }  // Optional: Species code.
        public string? GRAD_CD { get; set; }  // Optional: Grade code.
        public string? STNDRD_CD { get; set; }  // Optional: Standard code.

        /// <summary>
        /// Constructor for 전국도매시장일별경락가격Request requiring an API key.
        /// </summary>
        /// <param name="apiKey">The API key to be used for the request, must be securely stored and passed.</param>
        public 전국도매시장일별경락가격Request(string apiKey)
        {
            API_KEY = apiKey;
        }
    }
}
