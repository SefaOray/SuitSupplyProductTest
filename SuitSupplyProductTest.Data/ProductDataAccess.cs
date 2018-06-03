using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuitSupplyProductTest.Data
{
    public class ProductDataAccess : IProductDataAccess
    {
        private readonly EfDbContext context;

        public ProductDataAccess(EfDbContext context)
        {
            this.context = context;
        }

        public Product InsertProduct(Product product)
        {
            if (product is null)
                throw new ArgumentNullException("product");

            product.LastUpdated = DateTime.Now;

            var entity = context.Products.Add(product);
            context.SaveChanges();
            return entity.Entity;
        }

        public void UpdateProduct(Product product)
        {
            if (product is null)
                throw new ArgumentNullException("product");

            context.Products.Attach(product);
            context.Entry(product).State = EntityState.Modified;
        }

        public Product GetProductById(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product GetProductByCode(string code)
        {
            return context.Products.FirstOrDefault(p => p.Code == code);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.AsEnumerable();
        }

        public void DeleteProduct(int productId)
        {
            var product = context.Products.Find(productId);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
