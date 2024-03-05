using CIS106ExceptionHandling.models;
using Microsoft.EntityFrameworkCore;

namespace CIS106ExceptionHandling.repositories {

    public class EhDbContext: DbContext {

        // This holds our configurations for our application, defined mostly in out appsettings.json files.
        private readonly IConfiguration _configuration;

        // This holds our entities that we want to appear in our database as tables.
        public DbSet<Product> Products {get; set;}

        /* This constructor allows our IConfiguration to be injected into it by the .NET framework.
        * We don't have to worry about how it gets into our class, .NET takes care of that for us
        * with its dependency injection container.
        */
        public EhDbContext(IConfiguration configuration) {
            this._configuration = configuration;
        }

        /* Overriding this method allows us to setup the database connection strings
        * as well as tell Entity Framework what database type to use (sqlite)
        * on top of some other configurations, like telling it to log our SQL and such to the console
        * and provide detailed error messages rather than shorter ones.
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Tells EF Core to use our database connection string from our appsettings.json
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));

            // Enable EF Core logging (logs the SQL it generates and more)
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

            // Enable more verbose error explanations.
            optionsBuilder.EnableDetailedErrors();
        }

        /*  method provided by Entity Framework Core that allows you to configure the model for your DbContext.
        * It is called when the DbContext is being initialized, typically during application startup. 
        * Inside this method, you can use the ModelBuilder instance to configure various aspects of your entity types,
        * such as defining primary keys, specifying relationships between entities, configuring property mappings, setting up data seeding, and more. 
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed the database with 20 products
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Hammer", Description = "Claw hammer for general purpose use", Price = 15.99m },
            new Product { Id = 2, Name = "Screwdriver Set", Description = "Set of Phillips and flat-head screwdrivers", Price = 9.99m },
            new Product { Id = 3, Name = "Drill", Description = "Cordless drill with rechargeable battery", Price = 49.99m },
            new Product { Id = 4, Name = "Pliers", Description = "Set of needle-nose and lineman's pliers", Price = 12.49m },
            new Product { Id = 5, Name = "Tape Measure", Description = "25-foot retractable tape measure", Price = 7.99m },
            new Product { Id = 6, Name = "Saw", Description = "Hand saw for cutting wood and plastic", Price = 18.99m },
            new Product { Id = 7, Name = "Paint Roller Set", Description = "Set of paint rollers and tray", Price = 14.99m },
            new Product { Id = 8, Name = "Nails Assortment", Description = "Assorted nails for various applications", Price = 5.99m },
            new Product { Id = 9, Name = "Screws Assortment", Description = "Assorted screws for various applications", Price = 6.99m },
            new Product { Id = 10, Name = "Extension Cord", Description = "10-foot extension cord for indoor use", Price = 8.99m },
            new Product { Id = 11, Name = "Utility Knife", Description = "Retractable utility knife with replaceable blades", Price = 4.49m },
            new Product { Id = 12, Name = "Safety Glasses", Description = "Protective eyewear for use in workshops", Price = 3.99m },
            new Product { Id = 13, Name = "Work Gloves", Description = "Pair of heavy-duty work gloves", Price = 9.99m },
            new Product { Id = 14, Name = "Caulk Gun", Description = "Manual caulking gun for applying sealant", Price = 6.49m },
            new Product { Id = 15, Name = "Door Lock Set", Description = "Set of locks for interior doors", Price = 19.99m },
            new Product { Id = 16, Name = "Sandpaper Assortment", Description = "Assorted grit sandpaper for sanding surfaces", Price = 3.99m },
            new Product { Id = 17, Name = "Flashlight", Description = "LED flashlight with adjustable focus", Price = 11.99m },
            new Product { Id = 18, Name = "Cordless Screwdriver", Description = "Compact cordless screwdriver with magnetic tip", Price = 24.99m },
            new Product { Id = 19, Name = "Caulk", Description = "Waterproof sealant for sealing gaps and cracks", Price = 5.49m },
            new Product { Id = 20, Name = "Stud Finder", Description = "Electronic stud finder for locating studs in walls", Price = 14.99m }
        );
    }

    }

}