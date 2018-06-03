using System.Collections.Generic;
using SuitSupplyProductTest.Data;

namespace SuitSupplyProductTest.Services
{
    /// <summary>
    /// Business layer for Product
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductDataAccess productDataAccess;

        public ProductService(IProductDataAccess productDataAccess)
        {
            this.productDataAccess = productDataAccess;
        }

        /// <summary>
        /// Add a new Product to data source
        /// </summary>
        /// <param name="product">Product to add</param>
        /// <returns>Product added to source</returns>
        public Product AddProduct(Product product)
        {
            return productDataAccess.InsertProduct(product);
        }

        /// <summary>
        /// Get a product by code
        /// </summary>
        /// <param name="code">code</param>
        /// <returns>Product</returns>
        public Product GetProductByCode(string code)
        {
            return productDataAccess.GetProductByCode(code);
        }

        /// <summary>
        /// Get a product by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Product</returns>
        public Product GetProductById(int id)
        {
            return productDataAccess.GetProductById(id);
        }

        /// <summary>
        /// Get all products in the data source
        /// </summary>
        /// <returns>Products</returns>
        public IEnumerable<Product> GetProducts()
        {
            return productDataAccess.GetProducts();
        }

        /// <summary>
        /// Update a product in the data source
        /// </summary>
        /// <param name="product">Product to update</param>
        public void UpdateProduct(Product product)
        {
            productDataAccess.UpdateProduct(product);
        }

        /// <summary>
        /// Delete a product from data source
        /// </summary>
        /// <param name="product">Product to delete</param>
        public void DeleteProduct(Product product)
        {
            productDataAccess.DeleteProduct(product);
        }
    }
}
