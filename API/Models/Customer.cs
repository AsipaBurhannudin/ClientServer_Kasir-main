using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("customer")]
    public class Customer
    {
        [Key, Column("customer_id", TypeName = "int")]
        public int customer_id { get; set; }

        [Column("customer_name", TypeName = "varchar(50)")]
        public string customer_name { get; set; }

        [Column("address", TypeName = "varchar(255)")]
        public string address { get; set; }

        [Column("phone_number", TypeName = "varchar(50)")]
        public string phone_number { get; set; }
    }
}