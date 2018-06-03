using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuitSupplyProductTest.Data;
using SuitSupplyProductTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuitSupplyProductTest.Tests.Services
{
    [TestClass]
    public class ProductServiceTests
    {
        private readonly Mock<IProductDataAccess> dataAccessMock;
        private readonly ProductService productService;
        public ProductServiceTests()
        {
            dataAccessMock = new Mock<IProductDataAccess>();

            dataAccessMock.Setup(m => m.InsertProduct(It.IsAny<Product>())).Returns((Product p) => p);

            productService = new ProductService(dataAccessMock.Object);
        }

        [TestMethod]
        public void AddProductCallsInsertProduct()
        {
            productService.AddProduct(new Product());

            dataAccessMock.Verify(m => m.InsertProduct(It.IsAny<Product>()), Times.Once);
        }

        [TestMethod]
        public void DeleteProductCallsDeleteProduct()
        {
            productService.DeleteProduct(new Product());

            dataAccessMock.Verify(m => m.DeleteProduct(It.IsAny<Product>()), Times.Once);
        }

        [TestMethod]
        public void GetProductByCodeCallsGetProductByCode()
        {
            productService.GetProductByCode("abc");

            dataAccessMock.Verify(m => m.GetProductByCode(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void GetProductByIdCallsGetProductById()
        {
            productService.GetProductById(1);

            dataAccessMock.Verify(m => m.GetProductById(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetProductsCallsGetProducts()
        {
            productService.GetProducts();

            dataAccessMock.Verify(m => m.GetProducts(), Times.Once);
        }

        [TestMethod]
        public void UpdateProductCallsUpdateProduct()
        {
            productService.UpdateProduct(new Product());

            dataAccessMock.Verify(m => m.UpdateProduct(It.IsAny<Product>()), Times.Once);
        }
    }
}
