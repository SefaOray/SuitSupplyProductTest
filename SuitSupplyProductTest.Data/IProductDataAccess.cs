using System.Collections.Generic;

namespace SuitSupplyProductTest.Data
{
    /// <summary>
    /// Data layer for Product
    /// </summary>
    public interface IProductDataAccess
    {
        /// <summary>
        /// Add new product to database
        /// </summary>
        /// <param name="product">Product to add </param>
        /// <returns>Product saved to data source</returns>
        Product InsertProduct(Product product);

        /// <summary>
        /// Get a product by Id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Product</returns>
        Product GetProductById(int id);

        /// <summary>
        /// Get a product by code
        /// </summary>
        /// <param name="code">Code</param>
        /// <returns>Product</returns>
        Product GetProductByCode(string code);

        /// <summary>
        /// Get all products in the database
        /// </summary>
        /// <returns>Products</returns>
        IEnumerable<Product> GetProducts();

        /// <summary>
        /// Update a product in the database
        /// </summary>
        /// <param name="product">Product to update</param>
        void UpdateProduct(Product product);

        /// <summary>
        /// Delete a product from database
        /// </summary>
        /// <param name="product">Product to delete</param>
        void DeleteProduct(Product product);
    }
}