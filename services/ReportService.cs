using CIS106ExceptionHandling.exceptions;
using CIS106ExceptionHandling.models;
using CIS106ExceptionHandling.services;

namespace CIS106ExceptionHandling.services {

    /// <summary>
    /// Generates Reports.
    /// </summary>
    public class ReportService {

        // Only secret agents may view this product. They know the secret path to view it. Anyone calling for this is unauthorized.
        private static readonly int SUPER_SECRET_PRODUCT_ID = 999;

        // This hardcoded dictionary holds a map of product ID's to sales made in the last 30 days.
        // For example, the product with ID 1 has sold 0 units in the last 30 days.
        // These values are just made up and ensures you will have to handle for divide by zero exceptions.
        private static readonly Dictionary<int, int> PRODUCT_SALES_LAST_30_DAYS = new Dictionary<int, int> {
            {1, 0}, {2, 50}, {3, 20}, {4, 40}, {5, 40}, {6, 0}, {7, 30}, {8, 14}, {9, 55}, {10, 0}, {11, 32}, {12, 23}, {13, 65},
            {14, 0}, {15, 41}, {16, 14}, {17, 52}, {18, 33}, {19, 78}, {20, 0}, {21, 22}, {22, 11}, {23, 1}, {24, 1}, {25, 0}, {26, 0},
        };

        /* This is the ReportService's own reference to the ProductService.
        * We don't initialize it here as we will let .NET provide us with a complete
        * ProductService via Constructor dependency injection below.
        */
        private readonly ProductService _productService;


        /// <summary>
        /// Constructor for dependency injection. This constructor allows our ProductService to be injected into it by the .NET framework. 
        /// We don't have to worry about how it gets into our class, .NET takes care of that for us with its dependency injection container.
        /// </summary>
        /// <param name="productService">The ProductService to use.</param>
        public ReportService(ProductService productService) {
            this._productService = productService;
        }

        /// <summary>
        /// Generates the report for the product tied to the given product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to generate the report for.</param>
        /// <returns>The report to return.</returns>
        public Report GenerateReport(int productId) {
            // TODO: Handle the exceptions presented in the assignment.
            Report report = new Report();

            try
            {
                Product? productForReport = this._productService.GetProductById(productId);

                if (productId == SUPER_SECRET_PRODUCT_ID)
                {
                    throw new UnauthorizedException("User is unauthorized for this resource.");
                }

                report.Product = productForReport;
                report.TotalSalesPastThirtyDays = PRODUCT_SALES_LAST_30_DAYS[productForReport.Id];

                report.DailySalesPastThirtyDays = 30m / report.TotalSalesPastThirtyDays;

                report.GrossIncome = report.DailySalesPastThirtyDays * productForReport.Price;
            }  
            catch (DivideByZeroException)
            {
                report.DailySalesPastThirtyDays = 0;
            }
            catch (NullReferenceException)
            {
                throw new EntityNotFoundException($"Product with ID {productId} could not be found. Could not generate report."); 
            }

            return report;
        }

    }

}