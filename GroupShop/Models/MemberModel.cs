
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace GroupShop.Models
{
    [Table("MEMBERS")]
    public class Member
    {
        [Key]
        [Column("MEMBERID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MemberId { get; set; }


        [Display(Name = "身分證字號")]
        [Column("PERSONID")]
        public string PersonId { get; set; }

        [Display(Name = "姓名")]
        [Column("NAME")]
        public string Name { get; set; }

        [Display(Name = "電子郵件")]
        [Column("EMAIL")]
        public string Email { get; set; }

        [Display(Name = "手機")]
        [Column("PHONE")]
        public string Phone { get; set; }

        [Display(Name = "地址")]
        [Column("ADDRESS")]
        public string Address { get; set; }

       

    }

    public class MemberDbContext : OracleDbContext
    {

        public MemberDbContext()
            : base("OracleDbContext")
        {
        }

        public System.Data.Entity.DbSet<Member> Members { get; set; }

        

    }
}