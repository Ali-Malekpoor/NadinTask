using Microsoft.EntityFrameworkCore;
using Nadin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Nadin.Persistence.AppDbContext
{
    public class NadinDbContext : DbContext
    {
        #region ctor

        public NadinDbContext(DbContextOptions<NadinDbContext> options) : base(options)
        {
           
        }

        #endregion

        #region db sets

        public DbSet<Product> Products { get; set; }

        #endregion

        #region model creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        #endregion
    }
}
