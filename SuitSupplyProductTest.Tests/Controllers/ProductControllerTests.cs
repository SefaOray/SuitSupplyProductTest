using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using SuitSupplyProductTest.Services;
using SuitSupplyProductTest.Data;
using SuitSupplyProductTest.Controllers;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SuitSupplyProductTest.Models;

namespace SuitSupplyProductTest.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTests
    {
        private readonly ProductController productController;
        public ProductControllerTests()
        {
            var serviceMock = new Mock<IProductService>();

            serviceMock.Setup(m => m.GetProducts()).Returns(new List<Product>());
            serviceMock.Setup(m => m.GetProductById(It.IsAny<int>())).Returns(new Product());
            serviceMock.Setup(m => m.GetProductByCode(It.IsAny<string>())).Returns(new Product());
            serviceMock.Setup(m => m.AddProduct(It.IsAny<Product>())).Returns(new Product());

            productController = new ProductController(serviceMock.Object);
            Mapper.Reset();
            Mapper.Initialize(cfg =>
                cfg.CreateMap<ProductModel, Product>()
                    .ForMember(dest => dest.Id, opt => opt.UseValue(default(int)))
                    .ForMember(dest => dest.LastUpdated, opt => opt.UseValue(default(DateTime)))
            );
        }

        [TestMethod]
        public void GetAllProductReturnsOkCode()
        {
            var res = productController.Get();

            Assert.IsInstanceOfType(res, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetProductReturnOkWhenProductIsFound()
        {
            var res = productController.Get(1);

            Assert.IsInstanceOfType(res, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetProductReturnNotFoundWhenProductIsNotFound()
        {
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(m => m.GetProductById(It.IsAny<int>())).Returns(default(Product));

            var ctrl = new ProductController(serviceMock.Object);

            var res = ctrl.Get(1);

            Assert.IsInstanceOfType(res, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostReturnsCreatedResultWhenProductIsCreated()
        {
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(m => m.GetProductByCode(It.IsAny<string>()));
            serviceMock.Setup(m => m.AddProduct(It.IsAny<Product>())).Returns(new Product());

            var ctrl = new ProductController(serviceMock.Object);

            var res = ctrl.Post(new Models.ProductModel() { Code = "abc", Name = "abc", Price = 5 });

            Assert.IsInstanceOfType(res, typeof(CreatedAtActionResult));
        }

        [TestMethod]
        public void PostReturnsBadRequestResultWhenProductWithSameCodeExists()
        {
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(m => m.GetProductByCode(It.IsAny<string>())).Returns(new Product());

            var ctrl = new ProductController(serviceMock.Object);

            var res = ctrl.Post(new Models.ProductModel() { Code = "abc", Name = "abc", Price = 5 });

            Assert.IsInstanceOfType(res, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void PutReturnsBadRequestResultWhenProductWithSameCodeExists()
        {
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(m => m.GetProductByCode(It.IsAny<string>())).Returns(new Product() { Id = 2 });

            var ctrl = new ProductController(serviceMock.Object);

            var res = ctrl.Put(1,new Models.ProductModel() { Code = "abc", Name = "abc", Price = 5 });

            Assert.IsInstanceOfType(res, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void PutReturnsOkWhenProductIsUpdated()
        {
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(m => m.GetProductByCode(It.IsAny<string>())).Returns(default(Product));

            var ctrl = new ProductController(serviceMock.Object);

            var res = ctrl.Put(1, new Models.ProductModel() { Code = "abc", Name = "abc", Price = 5 });

            serviceMock.Verify(m => m.UpdateProduct(It.IsAny<Product>()), Times.Once);
            Assert.IsInstanceOfType(res, typeof(OkResult));
        }

        [TestMethod]
        public void DeleteReturnsBadRequestWhenProductIsNotFound()
        {
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(m => m.GetProductById(It.IsAny<int>())).Returns(default(Product));

            var ctrl = new ProductController(serviceMock.Object);

            var res = ctrl.Delete(1);

            Assert.IsInstanceOfType(res, typeof(BadRequestResult));
        }

        [TestMethod]
        public void DeleteReturnsBadRequestWhenProductIsDeleted()
        {
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(m => m.GetProductById(It.IsAny<int>())).Returns(new Product());

            var ctrl = new ProductController(serviceMock.Object);

            var res = ctrl.Delete(1);

            serviceMock.Verify(m => m.DeleteProduct(It.IsAny<Product>()), Times.Once);
            Assert.IsInstanceOfType(res, typeof(OkResult));
        }
    }
}
