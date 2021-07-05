using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Repository;


namespace Model
{
    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductValue { get; set; }

        public Product(
            string productName,
            double productValue
        )
        {
            ProductName = productName;
            ProductValue = productValue;

            var db = new Context();
            db.Products.Add(this);
            db.SaveChanges();
        }
        public Product()
        {
        }

        public static Product GetProduct(int productID)
        {
            var db = new Context();
            return (from product in db.Products
                    where product.ProductId == productID
                    select product).First();
        }
        public static List<Product> GetProducts()
        {
            var db = new Context();
            IEnumerable<Product> query = from Product in db.Products select Product;
            return query.ToList();
        }

        public static Product GetProductId(int productId)
        {
            var db = new Context();
            return db.Products.Find(productId);
        }

        public static void UpdateProduct(
            int productId,
            string productName,
            double productValue
        )
        {
            Product Product = GetProductId(productId);
            Product.ProductId = productId;
            Product.ProductName = productName;
            Product.ProductValue = productValue;

            var db = new Context();
            db.SaveChanges();
        }

        public static void DeleteProduct(int productId)
        {
            var db = new Context();

            Product product = db.Products.First(product => product.ProductId == productId);
            db.Remove(product);
            db.SaveChanges();
        }
    }
}