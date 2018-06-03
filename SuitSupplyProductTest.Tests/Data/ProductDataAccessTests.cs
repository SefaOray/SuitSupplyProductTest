using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuitSupplyProductTest.Data;

namespace SuitSupplyProductTest.Tests
{
    /*
    * Drafts for testing ProductDataAccess.
    * ProductDataAccess can't be tested with unit tests because of testing incapabilities of EF Core. 
    * In current EF Core version Add, FirstOrDefault, DbSet<T> and where methods / properties are unmockable.
    */
    [TestClass]
    public class ProductDataAccessTests
    {
        private readonly IProductDataAccess _productDataAccess;
        private readonly Mock<EfDbContext> _ctxMock;
        public ProductDataAccessTests()
        {
            _ctxMock = new Mock<EfDbContext>("conStr");
            
            _productDataAccess = new ProductDataAccess(_ctxMock.Object);
        }

        [TestMethod]
        public void InsertProductShouldReturnInsertedProduct()
        {
            
             
            var product = new Product() { Code = "Code", Name = "Name", Price = 123 };
            var insertedProduct = _productDataAccess.InsertProduct(product);

            _ctxMock.Verify(m => m.Products.Add(product), Times.Once());
            _ctxMock.Verify(m => m.SaveChanges(), Times.Once());
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