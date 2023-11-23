using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class ProductHandler
    {
        public static List<Product> GetProducts()
        {
            string[] list = File.ReadAllLines("../../../products.txt");

            List<Product> listOfProducts = new List<Product>();

            int i = 0;
            foreach (string line in list)
            {
                string[] parts = line.Split(',');
                Product product = new Product();
                product.ProductId = int.Parse(parts[0].ToString());
                product.Name = parts[1].ToString();
                product.Price = double.Parse(parts[2].ToString());
                product.PriceType = parts[3].ToString();

                listOfProducts.Add(product);
            }
            return listOfProducts;
        }
    }
}
