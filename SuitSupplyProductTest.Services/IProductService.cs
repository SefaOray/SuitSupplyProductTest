using SuitSupplyProductTest.Data;
using System;
using System.Collections.Generic;

namespace SuitSupplyProductTest.Services
{
    /// <summary>
    /// Business layer for Product
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Add a new Product to data source
        /// </summary>
        /// <param name="product">Product to add</param>
        /// <returns>Product added to source</returns>
        Product AddProduct(Product product);

        /// <summary>
        /// Get a product by code
        /// </summary>
        /// <param name="code">code</param>
        /// <returns>Product</returns>
        Product GetProductByCode(string code);

        /// <summary>
        /// Get a product by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Product</returns>
        Product GetProductById(int id);

        /// <summary>
        /// Get all products in the data source
        /// </summary>
        /// <returns>Products</returns>
        IEnumerable<Product> GetProducts();

        /// <summary>
        /// Update a product in the data source
        /// </summary>
        /// <param name="product">Product to update</param>
        void UpdateProduct(Product product);

        /// <summary>
        /// Delete a product from data source
        /// </summary>
        /// <param name="product">Product to delete</param>
        void DeleteProduct(Product product);
    }
}
