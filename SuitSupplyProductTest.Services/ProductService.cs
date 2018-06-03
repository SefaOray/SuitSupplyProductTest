using System.Collections.Generic;
using SuitSupplyProductTest.Data;

namespace SuitSupplyProductTest.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataAccess productDataAccess;

        public ProductService(IProductDataAccess productDataAccess)
        {
            this.productDataAccess = productDataAccess;
        }

        public Product AddProduct(Product product)
        {
            return productDataAccess.InsertProduct(product);
        }

        public Product GetProductByCode(string code)
        {
            return productDataAccess.GetProductByCode(code);
        }

        public Product GetProductById(int id)
        {
            return productDataAccess.GetProductById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productDataAccess.GetProducts();
        }

        public void UpdateProduct(Product product)
        {
            productDataAccess.UpdateProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            productDataAccess.DeleteProduct(product);
        }
    }
}
