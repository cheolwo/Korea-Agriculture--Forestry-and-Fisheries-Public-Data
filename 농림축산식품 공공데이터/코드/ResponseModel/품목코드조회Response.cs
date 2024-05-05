using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace 농림축산식품_공공데이터.코드.ResponseModel.품목코드
{
    [XmlRoot("Grid_20141221000000000120_1")]
    public class 품목코드조회Response
    {
        [XmlElement("totalCnt")]
        public int TotalCount { get; set; }

        [XmlElement("result")]
        public ResponseResult Result { get; set; }

        [XmlArray("row")]
        [XmlArrayItem("row")]
        public List<ProductRow> Rows { get; set; }
    }

    public class ResponseResult
    {
        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("code")]
        public string Code { get; set; }
    }

    public class ProductRow
    {
        [XmlElement("ROW_NUM")]
        public int RowNumber { get; set; }

        [XmlElement("CATGORY_CD")]
        public string CategoryCode { get; set; }

        [XmlElement("CATGORY_NM")]
        public string CategoryName { get; set; }

        [XmlElement("PRDLST_CD")]
        public string ProductCode { get; set; }

        [XmlElement("PRDLST_NM")]
        public string ProductName { get; set; }

        [XmlElement("SPCIES_CD")]
        public string SpeciesCode { get; set; }

        [XmlElement("SPCIES_NM")]
        public string SpeciesName { get; set; }
    }
}
