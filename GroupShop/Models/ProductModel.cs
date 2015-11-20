
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace GroupShop.Models
{
    [Table("PRODUCT")]
    public class Product
    {
        [Key]
        [Column("PRODUCTID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductId { get; set; }

        [Column("SUPPLIERID")]
        [Display(Name = "供應商")]
        public string SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Suppliers { get; set; }


        [Display(Name = "產品名稱")]
        [Column("NAME")]
        public string Name { get; set; }

        [Display(Name = "單價")]
        [Column("UNITPRICE")]
        public int UnitPrice { get; set; }


    }

    public class ProductDbContext : OracleDbContext
    {

        public ProductDbContext()
            : base("OracleDbContext")
        {
        }

        public System.Data.Entity.DbSet<Product> Products { get; set; }

        

    }
}