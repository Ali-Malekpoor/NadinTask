using Microsoft.EntityFrameworkCore;
using Nadin.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Nadin.Infrastructure.DataBaseContext
{
    public class NadinDbContext : DbContext
    {
        #region Ctor

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = Nadin; Integrated Security = True; Trust Server Certificate = True");
            base.OnConfiguring(optionsBuilder);
        }

        #endregion

        #region Db Sets

        public DbSet<Product> Products { get; set; } 

        #endregion
    }
}
