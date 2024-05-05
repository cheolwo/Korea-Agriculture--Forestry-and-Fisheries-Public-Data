```mermaid
erDiagram
    "부류" ||--o{ "품목" : "contains"
    "품목" ||--o{ "품종" : "contains"
    "품목" ||--|{ "부류" : "is part of"
    "품종" ||--|{ "품목" : "is part of"
    "품종" ||--o{ "도매법인별경락가격" : "has prices"
    "도매시장" ||--o{ "도매법인" : "hosts"
    "도매법인" ||--o{ "도매법인별경락가격" : "records prices"
    "도매법인" ||--|{ "도매시장" : "belongs to"

    "부류" {
        string Name "부류명"
        string Code PK "부류코드"
    }
    "품목" {
        string Name "품목명"
        string Code PK "품목코드"
        string "부류코드" FK "부류코드"
    }
    "품종" {
        string Code PK "품종코드"
        string "부류코드" FK "부류코드"
        string "품목코드" FK "품목코드"
    }
    "도매시장" {
        string Name "도매시장명"
        string Code PK "도매시장코드"
        string Address "주소"
    }
    "도매법인" {
        string "시장코드" FK "도매시장코드"
    }
    "도매법인별경락가격" {
        string "일자" PK "날짜"
        string "가격" "가격"
        string "도매법인코드" FK "도매법인코드"
        string "품종코드" FK "품종코드"
        string "등급코드" FK "등급코드"
    }
    "등급" {
        string "ame "등급명"
        string Code PK "등급코드"
    }


```
