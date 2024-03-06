using CIS106ExceptionHandling.models;
using CIS106ExceptionHandling.services;
using Microsoft.AspNetCore.Mvc;

namespace CIS106ExceptionHandling.controllers {

    /// <summary>
    /// Controller which exposes endpoints for generating reports.
    /// </summary>
    [ApiController]
    public class ReportController: ControllerBase {

        /* This is the ReportControllers's own reference to the ReportService.
        * We don't initiliaze it here as we will let .NET provide us with a complete
        * ReportService via Constructor dependency injection below.
        */
        private readonly ReportService _reportService;

        /// <summary>
        /// Constructor for dependency injection. This constructor allows our ReportService to be injected into it by the .NET framework. 
        /// We don't have to worry about how it gets into our class, .NET takes care of that for us with its dependency injection container.
        /// </summary>
        /// <param name="reportService">The ReportService to use.</param>
        public ReportController(ReportService reportService) {
            this._reportService = reportService;
        }

        /// <summary>
        /// Generates the report for a given product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("products/{productId}/reports", Name = "GenerateProductReport")]
        public Report GenerateReportFromProductId(int productId) {
            return this._reportService.GenerateReport(productId);
        }

    }

}