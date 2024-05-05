using System.Xml.Serialization;

namespace 농림축산식품_공공데이터.코드.ResponseModel.부류코드
{
    [XmlRoot("Grid_20220823000000000629_1")]
    public class 부류코드조회Response
    {
        [XmlElement("totalCnt")]
        public int TotalCount { get; set; }

        [XmlElement("result")]
        public ResponseResult Result { get; set; }

        [XmlArray("row")]
        [XmlArrayItem("row")]
        public List<CategoryRow> Rows { get; set; }
    }

    public class ResponseResult
    {
        [XmlElement("message")]
        public string Message { get; set; }

        [XmlElement("code")]
        public string Code { get; set; }
    }

    public class CategoryRow
    {
        [XmlElement("ROW_NUM")]
        public int RowNumber { get; set; }

        [XmlElement("LCLASSCODE")]
        public string LClassCode { get; set; }

        [XmlElement("LCLASSNAME")]
        public string LClassName { get; set; }
    }
}
