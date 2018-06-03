using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuitSupplyProductTest.Data
{
    /// <summary>
    /// EF DB access for Product
    /// </summary>
    public class ProductDataAccess : IProductDataAccess
    {
        private readonly EfDbContext context;

        public ProductDataAccess(EfDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Add new product to database
        /// </summary>
        /// <param name="product">Product to add </param>
        /// <returns>Product saved to data source</returns>
        public Product InsertProduct(Product product)
        {
            if (product is null)
                throw new ArgumentNullException("product");

            product.LastUpdated = DateTime.Now;

            var entity = context.Products.Add(product);
            context.SaveChanges();
            return entity.Entity;
        }

        /// <summary>
        /// Update a product in the database
        /// </summary>
        /// <param name="product">Product to update</param>
        public void UpdateProduct(Product product)
        {
            if (product is null)
                throw new ArgumentNullException("product");

            context.Products.Attach(product);
            context.Entry(product).State = EntityState.Modified;
        }

        /// <summary>
        /// Get a product by Id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Product</returns>
        public Product GetProductById(int id)
        {
            return context.Products.Find(id);
        }

        /// <summary>
        /// Get a product by code
        /// </summary>
        /// <param name="code">Code</param>
        /// <returns>Product</returns>
        public Product GetProductByCode(string code)
        {
            return context.Products.FirstOrDefault(p => p.Code == code);
        }

        /// <summary>
        /// Get all products in the database
        /// </summary>
        /// <returns>Products</returns>
        public IEnumerable<Product> GetProducts()
        {
            return context.Products.AsEnumerable();
        }

        /// <summary>
        /// Delete a product from database
        /// </summary>
        /// <param name="product">Product to delete</param>
        public void DeleteProduct(Product product)
        {
            if (product is null)
                throw new ArgumentNullException("product");

            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
