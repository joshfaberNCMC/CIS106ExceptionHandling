namespace CIS106ExceptionHandling.models {

    /// <summary>
    /// A simple report detailing the sales for a product.
    /// </summary>
    public class Report {

        public Product Product {get; set;} = null!;
        public int TotalSalesPastThirtyDays {get; set;}
        public decimal DailySalesPastThirtyDays {get; set;}
        public decimal GrossIncome {get; set;}

    }

}