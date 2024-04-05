using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace 농림축산식품_공공데이터.Model
{
    public class 부류표준품목코드
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RowNum { get; set; }

        [Required]
        [StringLength(2)]
        public string 부류코드 { get; set; }

        [Required]
        [StringLength(30)]
        public string 부류명 { get; set; }
    }
}
