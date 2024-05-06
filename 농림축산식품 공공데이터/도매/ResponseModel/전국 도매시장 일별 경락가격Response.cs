using System.Xml.Serialization;

namespace 농림축산식품_공공데이터.도매.ResponseModel
{
    [XmlRoot("Grid_20141119000000000012_1")]
    public class 전국_도매시장_일별_경락가격Response
    {
        [XmlElement("totalCnt")]
        public int TotalCount { get; set; }

        [XmlElement("result")]
        public ResultInfo Result { get; set; }

        [XmlArray("row")]
        [XmlArrayItem("row")]
        public List<MarketPriceInfo> MarketPrices { get; set; }
    }

    public class ResultInfo
    {
        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("code")]
        public string Code { get; set; }
    }

    public class MarketPriceInfo
    {
        [XmlElement("ROW_NUM")]
        public int RowNumber { get; set; }

        [XmlElement("AUCNG_DE")]
        public string AuctionDate { get; set; }

        [XmlElement("PBLMNG_WHSAL_MRKT_NM")]
        public string WholesaleMarketName { get; set; }

        [XmlElement("PBLMNG_WHSAL_MRKT_CD")]
        public string WholesaleMarketCode { get; set; }

        [XmlElement("CPR_NM")]
        public string CorporationName { get; set; }

        [XmlElement("CPR_CD")]
        public string CorporationCode { get; set; }

        [XmlElement("PRDLST_NM")]
        public string ProductName { get; set; }

        [XmlElement("PRDLST_CD")]
        public string ProductCode { get; set; }

        [XmlElement("SPCIES_NM")]
        public string SpeciesName { get; set; }

        [XmlElement("SPCIES_CD")]
        public string SpeciesCode { get; set; }

        [XmlElement("GRAD")]
        public string Grade { get; set; }

        [XmlElement("GRAD_CD")]
        public string GradeCode { get; set; }

        [XmlElement("DELNGBUNDLE_QY")]
        public int BundleQuantity { get; set; }

        [XmlElement("STNDRD")]
        public string Standard { get; set; }

        [XmlElement("STNDRD_CD")]
        public string StandardCode { get; set; }

        [XmlElement("DELNG_QY")]
        public int TradingQuantity { get; set; }

        [XmlElement("MUMM_AMT")]
        public decimal MinimumAmount { get; set; }

        [XmlElement("AVRG_AMT")]
        public decimal AverageAmount { get; set; }

        [XmlElement("MXMM_AMT")]
        public decimal MaximumAmount { get; set; }

        [XmlElement("AUC_CO")]
        public int AuctionCount { get; set; }
    }
}
