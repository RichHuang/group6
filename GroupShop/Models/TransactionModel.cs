
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace GroupShop.Models
{
    [Table("TRANSACTION")]
    public class Transaction
    {
        [Key]
        [Column("TID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Tid { get; set; }

        [Column("TEAMID")]
        public string TeamId { get; set; }

        [ForeignKey("TeamId")]
        public virtual Teambuy Teambuys { get; set; }


        [Display(Name = "交易時間")]
        [Column("TIME")]
        public DateTime? Time { get; set; }

        [Display(Name = "送貨地址")]
        [Column("ADDRESS")]
        public string Address { get; set; }


    }

    public class TransactionDbContext : OracleDbContext
    {

        public TransactionDbContext()
            : base("OracleDbContext")
        {
        }

        public System.Data.Entity.DbSet<Transaction> Transactions { get; set; }

        public System.Data.Entity.DbSet<GroupShop.Models.Teambuy> Teambuys { get; set; }
    }
}