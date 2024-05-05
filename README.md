```mermaid
erDiagram
    "Category" ||--o{ "Product" : "contains"
    "Product" ||--o{ "Variety" : "contains"
    "Product" ||--|{ "Category" : "is part of"
    "Variety" ||--|{ "Product" : "is part of"
    "Variety" ||--o{ "WholesalePrice" : "has prices"
    "WholesaleMarket" ||--o{ "WholesaleCompany" : "hosts"
    "WholesaleCompany" ||--o{ "WholesalePrice" : "records prices"
    "WholesaleCompany" ||--|{ "WholesaleMarket" : "belongs to"

    "Category" {
        string "Name" "부류명"
        string "Code" PK "부류코드"
    }
    "Product" {
        string "Name" "품목명"
        string "Code" PK "품목코드"
        string "CategoryCode" FK "부류코드"
    }
    "Variety" {
        string "Code" PK "품종코드"
        string "CategoryCode" FK "부류코드"
        string "ProductCode" FK "품목코드"
    }
    "WholesaleMarket" {
        string "Name" "도매시장명"
        string "Code" PK "도매시장코드"
        string "Address" "주소"
    }
    "WholesaleCompany" {
        string "MarketCode" FK "도매시장코드"
    }
    "WholesalePrice" {
        string "Date" PK "날짜"
        string "Price" "가격"
        string "CompanyCode" FK "도매법인코드"
        string "VarietyCode" FK "품종코드"
        string "GradeCode" FK "등급코드"
    }
    "Grade" {
        string "Name" "등급명"
        string "Code" PK "등급코드"
    }


```
