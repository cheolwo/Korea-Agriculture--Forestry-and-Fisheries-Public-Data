<h2 align="center"><strong><span style="color:red;">ER Diagram </span></strong></h2>

```mermaid
erDiagram
    "부류" ||--o{ "품목" : "contains"
    "부류" ||--o{ "품종" : "contains"
    "품목" ||--o{ "품종" : "contains"
    "품목" ||--|| "부류" : "is part of"
    "품종" ||--|| "부류" : "is part of"
    "품종" ||--|| "품목" : "is part of"
    "품종" ||--o{ "도매가격" : "has"
    "도매시장" ||--o{ "도매법인" : "hosts"
    "도매법인" ||--o{ "도매가격" : "has"
    "도매법인" ||--|| "도매시장" : "is part of"
    "도매가격" ||--|| "도매법인" : "is part of"
    "도매가격" ||--|| "품종" : "is part of"
    "도매가격" ||--|| "등급" : "has"
    "도매가격" ||--|| "규격" : "has"

    "부류" {
        string 이름 "Name"
        string 코드 PK "Code"
    }
    "품목" {
        string 이름 "Name"
        string 코드 PK "Code"
        string 부류코드 FK "CategoryCode"
    }
    "품종" {
        string 코드 PK "Code"
        string 부류코드 FK "CategoryCode"
        string 품목코드 FK "ProductCode"
    }
    "등급" {
        string 이름 "Name"
        string 코드 PK "Code"
    }
    "규격" {
        string 이름 "Name"
        string 코드 PK "Code"
    }
    "도매시장" {
        string 이름 "Name"
        string 코드 PK "Code"
        string 주소 "Address"
    }
    "도매법인" {
        string 이름 "Name"
        string 코드 PK "Code"
        string 시장코드 FK "MarketCode"
    }
    "도매가격" {
        string 날짜 PK "Date"
        decimal 최소금액 "MinimumAmount"
        decimal 평균금액 "AverageAmount"
        decimal 최대금액 "MaximumAmount"
        int 경매수 "AuctionCount"
        int 거래수량 "TradingQuantity"
        int 묶음수량 "BundleQuantity"
        string 법인코드 FK "CompanyCode"
        string 품종코드 FK "VarietyCode"
        string 등급코드 FK "GradeCode"
        string 규격코드 FK "StandardCode"
    }


```
