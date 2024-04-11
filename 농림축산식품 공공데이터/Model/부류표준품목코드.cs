using Common.Model;

namespace 농림축산식품_공공데이터.Model
{
    public class 부류 : Entity
    {
        public List<품목> 품목 { get; set; }
    }

    public class 품목 : Entity
    {
        public string 부류코드 { get; set; }
        public 부류 부류 { get; set; }
        public List<품종> 품종 { get; set; }
    }
    public class 품종 : Entity
    {
        public string 품목코드 { get; set; }
        public 품목 품목 { get; set; }
        public List<시장도매가격> 시장도매가격들 { get; set; }
        public List<시장소매가격> 시장소매가격들 { get; set; }
        public List<도매법인별경락가격> 도매법인별경락가격들 { get; set; }
    }
    public class 지역 : Entity
    {
        public List<시장> 시장 { get; set; }
    }
    public class 도매법인 : Entity
    {
        public string 시장코드 { get; set; }
        public 시장 시장 { get; set; }
        public List<도매법인별경락가격> 도매법인별경락가격들 { get; set; }
    }

    public class 시장도매가격 : Entity
    {
        public string 가격 { get; set; }
        public string 품종코드 { get; set; }
        public string 시장코드 { get; set; }
        public 품종 품종 { get; set; }
        public 시장 시장 { get; set; }
    }
    public class 시장 : Entity
    {
        public string 지역코드 { get; set; }
        public 지역 지역 { get; set; }
        public List<도매법인> 도매법인들 { get; set; }
        public List<시장도매가격> 시장도매가격들 { get; set; }
        public List<시장소매가격> 시장소매가격들 { get; set; }
    }

    public class 시장소매가격 : Entity
    {
        public string 가격 { get; set; }
        public string 품종코드 { get; set; }
        public string 시장코드 { get; set; }
        public 품종 품종 { get; set; }
        public 시장 시장 { get; set; }
    }
    public class 도매법인별경락가격 : Entity
    {
        public string 가격 { get; set; }
        public string 도매법인코드 { get; set; }
        public string 품종코드 { get; set; }
        public 도매법인 도매법인 { get; set; }
        public 품종 품종 { get; set; }
    }
}
