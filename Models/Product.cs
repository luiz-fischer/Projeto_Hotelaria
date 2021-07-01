using System;

namespace Model {
    public partial class Product {
        private int ProductId { get; set; }
        private string ProductName { get; set; }
        private double ProductValue { get; set; }

        public Product(
            int productId,
            string productName,
            double productValue)
        {
            ProductId = productId;
            ProductName = productName;
            ProductValue = productValue;
        }
    }
}