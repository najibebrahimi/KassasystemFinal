using System.Collections.Generic;

namespace Kassasystem
{
    struct Shop
    {
        public Product produkt;
        public int amount;
    }
    internal partial class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            string myOptions;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to my app!");
                Console.WriteLine("Option 1. New customer");
                Console.WriteLine("Option 0. exit");
                myOptions = Console.ReadLine();
                switch (myOptions)
                {
                    case "1":
                        NewCustomer();
                        break;
                }

            } while (myOptions != "0");
        }

        static void NewCustomer()
        { 
            List<Product> listOfProducts = CreateTextFile();

            List<Shop> shoppingList = new List<Shop>();
            do
            {
                Console.Clear();
                
                foreach (var item in shoppingList)
                {
                    Console.WriteLine(item.amount + " x " + item.produkt.Name + ": " + (item.produkt.Price * item.amount));
                }
                Console.WriteLine("kommando\n<productid> <amount>\npay");
                string komman = Console.ReadLine();

                if (komman == "pay") break;

                string[] parts = komman.Split(' ');


                foreach (Product product in listOfProducts)
                {
                    if (product.ProductId == int.Parse(parts[0]))
                    {
                        Shop p = new Shop();
                        p.produkt = product;
                        p.amount = Int32.Parse(parts[1]);
                        shoppingList.Add(p);
                    }
                }

            } while (true); 

            Kvitto(shoppingList.ToArray());
        }

       
        static List<Product> CreateTextFile()
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

        static void Kvitto(Shop[] list)
        {
            
            int totalPris = 0;
            using (var writer = new StreamWriter($"../../../receipt{DateTime.Today.ToString("d")}.txt"))
            {
                writer.WriteLine("Kvitto");
                writer.WriteLine(DateTime.Now.ToString());
                foreach (Shop item in list)
                {
                    
                    {
                        writer.WriteLine(item.amount + " x " + item.produkt.Name + ": " + (item.produkt.Price * item.amount));
                        
                        totalPris += (int)(item.produkt.Price * item.amount);
                    }
                }
                
                writer.WriteLine("Total: " + totalPris);
            }
        }
    }
}