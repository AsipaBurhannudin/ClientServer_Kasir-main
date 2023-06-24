using API.Repositories.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("item")]
    public class Item
    {
        [Key, Column("item_code", TypeName = "char(5)")]
        public string item_code { get; set; }

        [Column("item_name", TypeName = "varchar(50)")]
        public string item_name { get; set; }

        [Column("stock", TypeName = "int")]
        public int stock { get; set; }

        [Column("selling_price", TypeName = "int")]
        public int selling_price { get; set; }

        [Column("purchase_price", TypeName = "int")]
        public int purchase_price { get; set; }
    }
}
