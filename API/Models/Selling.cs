using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("selling")]
    public class Selling
    {
        [Key, Column("user_code", TypeName = "char(5)")]
        public string user_code { get; set; }
        [Column("sales_code", TypeName = "char(5)")]
        public string sales_code { get; set; }
        [Column("sales_date", TypeName = "date")]
        public DateTime sales_date { get; set; }
        [Column("customer_id", TypeName = "int")]
        public int customer_id { get; set; }
        [Column("total_pay", TypeName = "int")]
        public int total_pay { get; set; }
    }
}
