using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuitSupplyProductTest.Data
{
    /// <summary>
    /// Data context for EF
    /// </summary>
    public class EfDbContext : DbContext
    {
        private readonly string _connectionStr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionStr">SQL Connection string</param>
        public EfDbContext(string connectionStr)
        {
            _connectionStr = connectionStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStr);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .ToTable("Products");
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
