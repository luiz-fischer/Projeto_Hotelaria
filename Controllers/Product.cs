using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controller
{
    public class Product
    {
        public static void AddProduct(string productName, double productValue)
        {
            if (productName == null || productValue == 0)
            {
                MessageBox.Show("Informações Inválidas");

            }

            new Model.Product(productName, productValue);
        }

        public static void UpdateProduct(
            int productId,
            string productName,
            double productValue
        )
        {
            Model.Product.UpdateProduct(productId, productName, productValue);
        }

        public static void DeleteProduct(int ProductId)
        {
            Model.Product.DeleteProduct(ProductId);
        }
        
        public static List<Model.Product> GetProducts() {
            return Model.Product.GetProducts();
        }

        public static Model.Product GetProduct(int ProductId)
        {
            return Model.Product.GetProduct(ProductId);
        }
    }
}
