using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("purchasedetails")]
    public class PurchaseDetails
    {
        [Key, Column("purchase_code", TypeName = "char(5)")]
        public string purchase_code { get; set; }
        [Column("item_code", TypeName = "char(5)")]
        public string item_code { get; set; }
        [Column("purchase_amount", TypeName = "int")]
        public int purchase_amount { get; set; }
        [Column("purchase_price", TypeName = "int")]
        public int purchase_price { get; set; }
    }
}
