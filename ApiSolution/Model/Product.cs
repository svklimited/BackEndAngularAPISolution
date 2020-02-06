using System;

namespace ApiSolution.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }      
        public decimal Price { get; set; }
        public int ProductQty { get; set; }
        public DateTime StockUpdatedOn { get; set; }

    }
}
