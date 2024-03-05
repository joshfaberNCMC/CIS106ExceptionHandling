using CIS106ExceptionHandling.models;
using CIS106ExceptionHandling.services;
using Microsoft.AspNetCore.Mvc;

namespace CIS106ExceptionHandling.controllers {

    /* This class is our Product Controller, which will contain endpoints that 
    * can be called by other applications. The only responsibility of this class
    * should be to validate and route the requests to the service layer.
    */
    [ApiController]
    public class ProductController: ControllerBase {

        /* This is the ProductControllers's own reference to the ProductService.
        * We don't initiliaze it here as we will let .NET provide us with a complete
        * ProductService via Constructor dependency injection below.
        */
        private readonly ProductService _productService;

        /* This constructor allows our ProductService to be injected into it by the .NET framework.
        * We don't have to worry about how it gets into our class, .NET takes care of that for us
        * with its dependency injection container.
        */
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

    }

}