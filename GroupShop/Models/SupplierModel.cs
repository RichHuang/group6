
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace GroupShop.Models
{
    [Table("SUPPLIER")]
    public class Supplier
    {
        [Key]
        [Column("SUPPLIERID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SupplierId { get; set; }

        [Display(Name = "供應商名稱")]
        [Column("NAME")]
        public string Name { get; set; }

        [Display(Name = "電話")]
        [Column("PHONE")]
        public string Phone { get; set; }

        [Display(Name = "地址")]
        [Column("ADDRESS")]
        public string Address { get; set; }

    }

    public class SupplierDbContext : OracleDbContext
    {

        public SupplierDbContext()
            : base("OracleDbContext")
        {
        }

        public System.Data.Entity.DbSet<Supplier> Suppliers { get; set; }

        

    }
}