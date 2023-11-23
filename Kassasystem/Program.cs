using System.Collections.Generic;

namespace Kassasystem
{
    // Istället för en struct 
    // skapa en klass i en ny fil
    //"ShopItem"
    //struct Shop
    //{
    //    // Byt ut till properties
    //    public Product produkt;
    //    public int amount;
    //}
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Menu.MainMenu();
           
        }

        // Bryta ut till en ny class kanske "CustomerHandler"
        //public static void NewCustomer()
        //{ 
        //    List<Product> listOfProducts = GetProducts();

        //    List<ShopItem> shoppingList = new List<ShopItem>();
        //    do
        //    {
        //        Console.Clear();
                
        //        foreach (var item in shoppingList)
        //        {
        //            Console.WriteLine(item.Amount + " x " + item.Produkt.Name + ": " + (item.Produkt.Price * item.Amount));
        //        }
        //        Console.WriteLine("kommando\n<productid> <amount>\npay");
        //        string komman = Console.ReadLine();

        //        if (komman == "pay") break;

        //        string[] parts = komman.Split(' ');


        //        foreach (Product product in listOfProducts)
        //        {
        //            if (product.ProductId == int.Parse(parts[0]))
        //            {
        //                ShopItem p = new ShopItem();
        //                p.Produkt = product;
        //                p.Amount = Int32.Parse(parts[1]);
        //                shoppingList.Add(p);
        //            }
        //        }

        //    } while (true); 

        //    CreateReceipt(shoppingList.ToArray());
        //}

       // Skapa en klass "ProductHandler"
        //static List<Product> GetProducts()
        //{
        //    string[] list = File.ReadAllLines("../../../products.txt");

        //    List<Product> listOfProducts = new List<Product>();
            
        //    int i = 0;
        //    foreach (string line in list)
        //    {
        //        string[] parts = line.Split(',');
        //        Product product = new Product();
        //        product.ProductId = int.Parse(parts[0].ToString());
        //        product.Name = parts[1].ToString();
        //        product.Price = double.Parse(parts[2].ToString());
        //        product.PriceType = parts[3].ToString();

        //        listOfProducts.Add(product);
        //    }
        //    return listOfProducts;
        //}

        // Skapa ReceiptHandler klass
        //static void CreateReceipt(ShopItem[] list)
        //{
        //    int totalPris = 0;
        //    using (var writer = new StreamWriter($"../../../receipt{DateTime.Today.ToString("d")}.txt"))
        //    {
        //        writer.WriteLine("Kvitto");
        //        writer.WriteLine(DateTime.Now.ToString());
        //        foreach (ShopItem item in list)
        //        {
                    
        //            {
        //                writer.WriteLine(item.Amount + " x " + item.Produkt.Name + ": " + (item.Produkt.Price * item.Amount));
                        
        //                totalPris += (int)(item.Produkt.Price * item.Amount);
        //            }
        //        }
                
        //        writer.WriteLine("Total: " + totalPris);
        //    }
        //}
    }
}