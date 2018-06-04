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
    [ApiVersion("1.0")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>Products</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult Get()
        {
            return Ok(_productService.GetProducts());
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
            var product = _productService.GetProductById(productId);

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

            var existingProduct = _productService.GetProductByCode(productModel.Code);

            if (existingProduct != null)
            {
                ModelState.TryAddModelError("Code", "A product with same Code already exists.");
                return BadRequest(ModelState);
            }

            var result = _productService.AddProduct(Mapper.Map<Product>(productModel));
            return CreatedAtAction(nameof(Get), new { productId = result.Id }, result);
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="productId">Product Id to update</param>
        /// <param name="productModel">New product values</param>
        /// <returns></returns>
        [HttpPut("{productId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Put(int productId, [FromBody]ProductModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(productId is default(int))
            {
                ModelState.TryAddModelError("Id", "Invalid Product Id");
                return BadRequest(ModelState);
            }

            var existingProduct = _productService.GetProductByCode(productModel.Code);

            if (existingProduct != null && existingProduct.Id != productId)
            {
                ModelState.TryAddModelError("Code", "A product with same Code already exists.");
                return BadRequest(ModelState);
            }

            var product = Mapper.Map<Product>(productModel);
            product.Id = productId;
            _productService.UpdateProduct(product);
            return Ok();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="productId">Product Id to delete</param>
        /// <returns></returns>
        [HttpDelete("{productId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Delete(int productId)
        {
            var product = _productService.GetProductById(productId);

            if (product is null)
                return BadRequest();

            _productService.DeleteProduct(product);
            return Ok();
        }
    }
}