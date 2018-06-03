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
            _productDataAccess = new ProductDataAccess();
        }

        [TestMethod]
        public void InsertProductShouldReturnInsertedProduct()
        {
            var product = new Product() { Code = "Code", Name = "Name", Price = 123 };
            var insertedProduct = _productDataAccess.InsertProduct(product);

            Assert.AreEqual("Code", insertedProduct.Code);
            Assert.AreEqual("Name", insertedProduct.Name);
            Assert.AreEqual(123, insertedProduct.Price);
        }

        [TestMethod]
        public void GetProductByIdShouldReturnProductWithSameId()
        {
            var product = _productDataAccess.GetProductById(1);
            Assert.AreEqual(1, product.Id);
        }

        [TestMethod]
        public void GetProductByCodeShouldReturnProductWithSameCode()
        {
            var product = _productDataAccess.GetProductByCode("code");
            Assert.AreEqual("code", product.Code);
        }
    }
}
