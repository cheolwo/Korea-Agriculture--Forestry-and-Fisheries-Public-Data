using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace 농림축산식품_공공데이터.Model
{
    public class 부류
    {
        public string 이름 { get; set; } // "Category name"
        public string 코드 { get; set; } // "Category code"
        public List<품목> 품목들 { get; set; } // "List of products"
        public List<품종> 품종들 { get; set; } // "List of varieties"
    }

    public class 품목
    {
        public string 이름 { get; set; } // "Product name"
        public string 코드 { get; set; } // "Product code"
        [ForeignKey("부류")]
        public string 부류코드 { get; set; } // "Category code"
        public 부류 부류 { get; set; } // "Category"
        public List<품종> 품종들 { get; set; } // "List of varieties"
    }

    public class 품종
    {
        public string 코드 { get; set; } // "Variety code"

        [ForeignKey("부류")]
        public string 부류코드 { get; set; } // "Category code"
        public 부류 부류 { get; set; } // "Category"

        [ForeignKey("품목")]
        public string 품목코드 { get; set; } // "Product code"
        public 품목 품목 { get; set; } // "Product"
        public List<도매가격> 도매가격들 { get; set; } // "List of wholesale prices"
    }

    public class 등급
    {
        [XmlElement("GRAD")]
        public string 이름 { get; set; } // "Grade name"

        [XmlElement("GRAD_CD")]
        public string 코드 { get; set; } // "Grade code"
    }

    public class 규격
    {
        [XmlElement("STNDRD")]
        public string 이름 { get; set; } // "Standard name"

        [XmlElement("STNDRD_CD")]
        public string 코드 { get; set; } // "Standard code"
    }

    public class 도매시장
    {
        [XmlElement("PBLMNG_WHSAL_MRKT_NM")]
        public string 이름 { get; set; } // "Wholesale market name"

        [XmlElement("PBLMNG_WHSAL_MRKT_CD")]
        [ForeignKey("도매시장")]
        public string 코드 { get; set; } // "Wholesale market code"
        public List<도매법인> 도매법인들 { get; set; } // "List of wholesale companies"
    }

    public class 도매법인
    {
        [XmlElement("CPR_NM")]
        public string 이름 { get; set; } // "Corporation name"

        [XmlElement("CPR_CD")]
        public string 코드 { get; set; } // "Corporation code"
        [XmlElement("PBLMNG_WHSAL_MRKT_CD")]
        public string 시장코드 { get; set; } // "Market code"
        public 도매시장 시장 { get; set; } // "Wholesale market"
        public List<도매가격> 도매가격들 { get; set; } // "List of wholesale prices"
    }

    public class 도매가격
    {
        [XmlElement("AUCNG_DE")]
        public string 날짜 { get; set; } // "Date"
        [XmlElement("MUMM_AMT")]
        public decimal 최소금액 { get; set; } // "Minimum amount"

        [XmlElement("AVRG_AMT")]
        public decimal 평균금액 { get; set; } // "Average amount"

        [XmlElement("MXMM_AMT")]
        public decimal 최대금액 { get; set; } // "Maximum amount"

        [XmlElement("AUC_CO")]
        public int 경매수 { get; set; } // "Auction count"
        [XmlElement("DELNG_QY")]
        public int 거래수량 { get; set; } // "Trading quantity"
        [XmlElement("DELNGBUNDLE_QY")]
        public int 묶음수량 { get; set; } // "Bundle quantity"

        [XmlElement("CPR_CD")]
        [ForeignKey("도매법인")]
        public string 법인코드 { get; set; } // "Company code"
        public 도매법인 법인 { get; set; } // "Wholesale company"

        [XmlElement("SPCIES_CD")]
        [ForeignKey("품종")]
        public string 품종코드 { get; set; } // "Variety code"
        public 품종 품종 { get; set; } // "Variety"

        [XmlElement("GRAD_CD")]
        [ForeignKey("등급")]
        public string 등급코드 { get; set; } // "Grade code"
        public 등급 등급 { get; set; } // "Grade"

        [XmlElement("STNDRD_CD")]
        [ForeignKey("규격")]
        public string 규격코드 { get; set; }
        public 규격 규굑 { get; set; }
    }
}
