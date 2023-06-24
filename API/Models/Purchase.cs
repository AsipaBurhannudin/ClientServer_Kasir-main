using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("customer")]
    public class Purchase
    {
        [Key, Column("purchase_code", TypeName = "char(5)")]
        public string purchase_code { get; set; }
        [Column("purchase_amount", TypeName = "int")]
        public int purchase_amount { get; set; }
        [Column("total_purchase", TypeName = "int")]
        public int total_purchase { get ; set; }
        [Column("purchase_date", TypeName = "DateOnly")]
        public DateOnly purchase_date { get; set; }
        [Column("total_pay", TypeName = "int")]
        public int total_pay { get; set; }
    }
}
