using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuitSupplyProductTest.Data
{
    public class EfDbContext : DbContext
    {
        private readonly string _connectionStr;

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

        internal DbSet<Product> Products { get; set; }
    }
}
