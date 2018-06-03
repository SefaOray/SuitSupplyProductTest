using System;

namespace SuitSupplyProductTest.Services
{
    public interface IProductService
    {
        Product AddProduct(Product product);
        Product GetProductByCode(string code);
        Product GetProductById(int id);
        IEnumerable<Product> GetProducts();
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        void DeleteProduct(int productId);
    }
}
