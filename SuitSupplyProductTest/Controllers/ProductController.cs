using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuitSupplyProductTest.Data;
using SuitSupplyProductTest.Models;
using SuitSupplyProductTest.Services;

namespace SuitSupplyProductTest.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController()
        {
            this.productService = productService;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>Products</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult Get()
        {
            return Ok(productService.GetProducts());
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>Product</returns>
        [HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(404)]
        public IActionResult Get(int productId)
        {
            var product = productService.GetProductById(productId);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        /// <summary>
        /// Save a new product
        /// </summary>
        /// <param name="productModel">Product</param>
        /// <returns>Product created</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody]ProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = productService.GetProductByCode(productModel.Code);

            if (existingProduct != null)
            {
                ModelState.TryAddModelError("Code", "A product with same Code already exists.");
                return BadRequest(ModelState);
            }

            var result = productService.AddProduct(Mapper.Map<Product>(productModel));
            return CreatedAtAction(nameof(Get), new { productId = result.Id }, result);
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="productId">Product Id to update</param>
        /// <param name="productModel">New product values</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Put(int productId, [FromBody]ProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = productService.GetProductByCode(productModel.Code);

            if (existingProduct != null && existingProduct.Id != productId)
            {
                ModelState.TryAddModelError("Code", "A product with same Code already exists.");
                return BadRequest(ModelState);
            }

            productService.UpdateProduct(Mapper.Map<Product>(productModel));
            return Ok();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="productId">Product Id to delete</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Delete(int productId)
        {
            var product = productService.GetProductById(productId);

            if (product is null)
                return BadRequest();

            productService.DeleteProduct(product);
            return Ok();
        }
    }
}