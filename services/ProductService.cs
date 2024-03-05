using CIS106ExceptionHandling.exceptions;
using CIS106ExceptionHandling.models;
using CIS106ExceptionHandling.repositories;
using Microsoft.Data.SqlClient;

namespace CIS106ExceptionHandling.services {

    public class ProductService {

        /* This is the ProductService's own reference to the EhDbContext.
        * We don't initiliaze it here as we will let .NET provide us with a complete
        * EhDbContext via Constructor dependency injection below.
        */
        private readonly EhDbContext _context;

        /* This constructor allows our EhDbContext to be injected into it by the .NET framework.
        * We don't have to worry about how it gets into our class, .NET takes care of that for us
        * with its dependency injection container.
        */
        public ProductService(EhDbContext context) {
            this._context = context;
        }

        /// <summary>
        /// Returns the list of products whose names match the criteria.
        /// If no criteria is provided, then all products are returned.
        /// </summary>
        /// <param name="criteria">The optional criteria to match products against.</param>
        /// <returns>The list of products to return.</returns>
        public List<Product> GetProducts(string? criteria) {
            // We first check if criteria is provided (not null).
            if (!string.IsNullOrEmpty(criteria)) {

                // If criteria was provided, let's put it into upper case here 
                // so we don't have to put it to upper case in every check.
                // We want to compare our criteria and our product names without case sensitivity.
                string formattedCriteria = criteria.ToUpper();

                // We are going to return our products WHERE the product's uppercased name CONTAINS the uppercased criteria.
                return this._context.Products
                    .Where(product => product.Name.ToUpper().Contains(formattedCriteria))
                    .ToList();
            } else {
                // If no criteria was sent in, we'll just return the full list of our products.
                return this._context.Products.ToList();
            }
        }

        /// <summary>
        /// Retrieves the Product with the given id, or null if not found.
        /// </summary>
        /// <param name="productId">The id of the product to retrieve.</param>
        /// <returns>The product or null if not found.</returns>
        public Product? GetProductById(int productId) {
            // Find will find an entity based on its primary key (unique identifier), if not found it returns null.
            // Alternatively you could do a .Where(product => product.id == id).FirstOrDefault() for the same functionality.
            return this._context.Products.Find(productId);
        }

        /// <summary>
        /// Saves a new product.
        /// </summary>
        /// <param name="request">The ProductCreateRequest to create the product from.</param>
        /// <returns>The created product (with its generated ID).</returns>
        public Product CreateProduct(ProductSaveRequest request)
        {
            // Instantiate a new Product based on the request.
            Product productToCreate = new Product{
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            // Add our new product to our DbSet of products.
            this._context.Products.Add(productToCreate);

            // Tells Entity Framework to process the add (also sets the Id field of the productToCreate).
            this._context.SaveChanges();

            // Return the created product.
            return productToCreate;
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="request">The ProductSaveRequest to use.</param>
        /// <param name="productId">The ID of the product to update.</param>
        /// <exception cref="EntityNotFoundException">Thrown if the product to update is not found.</exception>

        public void UpdateProduct(ProductSaveRequest request, int productId)
        {
            // To update an entity in Entity Framework, we first need to retrieve said product.
            Product? productToUpdate = this.GetProductById(productId);

            // If the product is found, we will update it and call SaveChanges on our DbContext.
            if (productToUpdate != null) {
                
                // Update the values of our product to update.
                productToUpdate.Name = request.Name;
                productToUpdate.Description = request.Description;
                productToUpdate.Price = request.Price;

                // Save the updated product.
                this._context.SaveChanges();
            } else {
                // Otherwise, if the product is null, we're going to throw our custom EntityNotFoundException with a useful message.
                throw new EntityNotFoundException($"Product with ID {productId} could not be found. Unable to update product.");
            }
        }


        /// <summary>
        /// Deletes the product with the given ID.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <exception cref="EntityNotFoundException">Thrown if the product to delete is not found.</exception>
        public void DeleteProductById(int productId)
        {
            // To delete an entity in Entity Framework, we first need to retrieve said product.
            Product? productToDelete = this.GetProductById(productId);

            // If the product is found, we will delete it by calling Remove, and SaveChanges, on our DbContext.
            if (productToDelete != null) {
                this._context.Remove(productToDelete);
                this._context.SaveChanges();
            } else {
                // Otherwise, if the product is null, we're going to throw our custom EntityNotFoundException with a useful message.
                throw new EntityNotFoundException($"Product with ID {productId} could not be found. Unable to delete product.");
            }
        }

    }

}