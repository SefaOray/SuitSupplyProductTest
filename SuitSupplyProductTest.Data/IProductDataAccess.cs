using System.Collections.Generic;

namespace SuitSupplyProductTest.Data
{
    public interface IProductDataAccess
    {
        Product InsertProduct(Product product);
        Product GetProductById(int id);
        Product GetProductByCode(string code);
        IEnumerable<Product> GetProducts();
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}