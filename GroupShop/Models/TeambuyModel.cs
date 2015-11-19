
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace GroupShop.Models
{
    [Table("TEAMBUY")]
    public class Teambuy
    {
        [Key]
        [Column("TEAMID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TeamId { get; set; }

        [Display(Name = "開團人員")]
        [Column("MEMBERID")]
        public string MemberId { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Members { get; set; }


        [Display(Name = "開始日期")]
        [Column("STARTDATE", TypeName = "Date")]
        public DateTime? Startdate { get; set; }

        [Display(Name = "結束日期")]
        [Column("ENDDATE", TypeName = "Date")]
        public DateTime? Enddate { get; set; }


        [Display(Name = "成團條件($)")]
        [Column("LEASTAMOUNT")]
        public int LeastAmount { get; set; }

        [Display(Name = "狀態")]
        [Column("STATUS")]
        public string Status { get; set; } //1 開團 2成團 3流團

        
        public override string ToString() {
            TeambuyDbContext db = new TeambuyDbContext();
            TeamOrder t = db.TeamOrders.FirstOrDefaultAsync(m => m.TeamId == this.TeamId).Result;


            return Members.Name + "的" + (t!= null?t.Products.Suppliers.Name:"")+ "團購";
        }

    }


    [Table("TEAMORDER")]
    public class TeamOrder
    {
        [Key]
        [Column("MEMBERID", Order = 1)]
        public string MemberId { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Members { get; set; }

        [Key]
        [Column("TEAMID", Order = 2)]
        public string TeamId { get; set; }

        [ForeignKey("TeamId")]
        public virtual Teambuy Teambuys { get; set; }

        [Key]
        [Column("PRODUCTID", Order = 3)]
        public string ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; }

        [Display(Name = "總金額")]
        [Column("AMOUNT")]
        public int Amount { get; set; }

        [Display(Name = "數量")]
        [Column("QUANTITY")]
        public int Quantity { get; set; }

       



    }

    public class TeambuyDbContext : OracleDbContext
    {

        public TeambuyDbContext()
            : base("OracleDbContext")
        {
        }

        public System.Data.Entity.DbSet<Teambuy> Teambuys { get; set; }
        public System.Data.Entity.DbSet<TeamOrder> TeamOrders { get; set; }



    }
}