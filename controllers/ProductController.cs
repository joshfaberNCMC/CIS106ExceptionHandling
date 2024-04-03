using System.ComponentModel.DataAnnotations;
using CIS106ExceptionHandling.exceptions;
using CIS106ExceptionHandling.models;
using CIS106ExceptionHandling.services;
using Microsoft.AspNetCore.Mvc;

namespace CIS106ExceptionHandling.controllers {

    /// <summary>
    /// This class is our Product Controller, which will contain endpoints that can be called by other applications. 
    /// The only responsibility of this class should be to validate and route the requests to the service layer.
    /// </summary>
    [ApiController]
    public class ProductController: ControllerBase {

        /* This is the ProductControllers's own reference to the ProductService.
        * We don't initialize it here as we will let .NET provide us with a complete
        * ProductService via Constructor dependency injection below.
        */
        private readonly ProductService _productService;

        /// <summary>
        /// Constructor for dependency injection. This constructor allows our ProductService to be injected into it by the .NET framework. 
        /// We don't have to worry about how it gets into our class, .NET takes care of that for us with its dependency injection container.
        /// </summary>
        /// <param name="productService">The ProductService to use.</param>
        public ProductController(ProductService productService) {
            this._productService = productService;
        }

        /// <summary>
        /// Returns the list of products matching the given criteria if provided.
        /// If no criteria is provided, this will return all products.
        /// </summary>
        /// <param name="criteria">The optional criteria, which comes from the URL query param ?criteria= to match product names against.</param>
        /// <returns>The list of products to return.</returns>
        [HttpGet("products", Name = "GetProducts")]
        public List<Product> GetProducts([FromQuery] string? criteria) {
            return this._productService.GetProducts(criteria);
        }

        /// <summary>
        /// Retrieves a single product by its ID, or null if not found.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>The product to return, or null if not found.</returns>
        [HttpGet("products/{productId}", Name = "GetProductById")]
        public Product? GetProductById([Required] [Range(1, int.MaxValue)] int productId) {
            return this._productService.GetProductById(productId);
        }

        /// <summary>
        /// Creates a new product based off the request.
        /// </summary>
        /// <param name="request">The ProductSaveRequest to create a product from.</param>
        /// <returns>The created Product to return.</returns>
        [HttpPost("products", Name = "CreateProduct")]
        public Product CreateProduct([FromBody] ProductSaveRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidInputException("Product Create Request is invalid.", ModelState);
            }
            else
            {
                return this._productService.CreateProduct(request);
            }
        }

        /// <summary>
        /// Updates an existing product based on the given request.
        /// </summary>
        /// <param name="request">The ProductSaveRequest to use.</param>
        /// <param name="productId">The ID of the product to update.</param>
        [HttpPut("products/{productId}", Name = "UpdateProduct")]
        public void UpdateProduct(
            [FromBody] ProductSaveRequest request, [Required] [Range(1, int.MaxValue)] int productId) {
            if (!ModelState.IsValid) {
                throw new InvalidInputException("Product Update Request is invalid. ", ModelState);
            } else {
                this._productService.UpdateProduct(request, productId);
            }
        }

        /// <summary>
        /// Deletes a product with the given product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        [HttpDelete("products/{productId}", Name = "DeleteProductById")]
        public void DeleteProductById([Required] [Range(1, int.MaxValue)] int productId) {
                this._productService.DeleteProductById(productId);
        }

    }

}