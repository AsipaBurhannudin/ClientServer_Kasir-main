using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("salesdetails")]
    public class Salesdetails
    {
        [Key, Column("sales_code", TypeName = "char(5)")]
        public string sales_code { get; set; }
        [Column("item_code", TypeName = "char(5)")]
        public string item_code { get; set; }
        [Column("item_amount", TypeName = "int")]
        public int item_amount { get; set; }
        [Column("selling_price", TypeName = "int")]
        public int selling_price { get; set; }
    }
}
