using System.Data.Entity;

namespace GroupShop.Models
{
    public class OracleDbContext : DbContext
    {

        public OracleDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("GROUP6");

            // ...
        }
    }
}