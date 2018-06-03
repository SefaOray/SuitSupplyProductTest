using Microsoft.EntityFrameworkCore;
using SuitSupplyProductTest.Data.Config;
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
        private readonly DataConfig _config;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config">DataConfig</param>
        public EfDbContext(DataConfig config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.SqlConfig.ConnectionStr);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .ToTable("Products");
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
