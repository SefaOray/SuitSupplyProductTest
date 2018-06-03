using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuitSupplyProductTest.Data;

namespace SuitSupplyProductTest.Tests
{
    [TestClass]
    public class ProductDataAccessTests
    {
        private readonly IProductDataAccess _productDataAccess;
        public ProductDataAccessTests()
        {
            
        }
        [TestMethod]
        public void InsertProductShouldReturnInsertedProduct()
        {
            var product = new Product();

        }

        [TestMethod]
        public void GetProductByIdShouldReturnProductWithSameId()
        {
            var product = new Product();
        }

        [TestMethod]
        public void GetProductByCodeShouldReturnProductWithSameCode()
        {
            var product = new Product();
        }
    }
}
