using CIS106ExceptionHandling.models;

namespace CIS106ExceptionHandling.services {

    public class ReportService {

        // This hardcoded dictionary holds a map of product ID's to sales made in the last 30 days.
        // For example, the product with ID 1 has sold 0 units in the last 30 days.
        // These values are just made up and ensures you will have to handle for divide by zero exceptions.
        private static readonly Dictionary<int, int> PRODUCT_SALES_LAST_30_DAYS = new Dictionary<int, int> {
            {1, 0}, {2, 50}, {3, 20}, {4, 40}, {5, 40}, {6, 0}, {7, 30}, {8, 14}, {9, 55}, {10, 0}, {11, 32}, {12, 23}, {13, 65},
            {14, 0}, {15, 41}, {16, 14}, {17, 52}, {18, 33}, {19, 78}, {20, 0}, {21, 22}, {22, 11}, {23, 1}, {24, 1}, {25, 0}, {26, 0},
        };

        private readonly ProductService _productService;

        public ReportService(ProductService productService) {
            this._productService = productService;
        }

        /// <summary>
        /// Generates the report for the product tied to the given product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to generate the report for.</param>
        /// <returns>The report to return.</returns>
        public Report GenerateReport(int productId) {
            /* TODO: Handle any exceptions that may occur.
            * 1. DivideByZeroException should be handled by setting the result to 0 and moving forward.
            * 2. If a product is not found, use exceptions to return a 404 NOT FOUND to the requester with a helpful message.
            * 3. Product 999 is a special product that only secret agents can view. If the product ID is 999, you must return to the requester
            * - a 401 UNAUTHORIZED HTTP Code Response with a message saying they are not authorized to view this product. This will require a new
            * - exception being created. */
            Report report = new Report();

            Product? productForReport = this._productService.GetProductById(productId);

            report.Product = productForReport;

            report.TotalSalesPastThirtyDays = PRODUCT_SALES_LAST_30_DAYS[productForReport.Id];
            report.DailySalesPastThirtyDays = 30m / report.TotalSalesPastThirtyDays;

            report.GrossIncome = report.DailySalesPastThirtyDays * productForReport.Price;

            return report;
        }

    }

}