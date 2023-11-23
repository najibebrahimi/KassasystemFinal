using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class CustomerHandler
    {
        public static void NewCustomer()
        {
            List<Product> listOfProducts = ProductHandler.GetProducts();

            List<ShopItem> shoppingList = new List<ShopItem>();
            
            
                
                bool success = false;
                int productId = 0;  
                int amount = 0;

                while (true)
                {
                    Console.Clear();
                    foreach (var item in shoppingList)
                    {
                        Console.WriteLine(item.Amount + " x " + item.Produkt.Name + ": " + (item.Produkt.Price * item.Amount));
                    }
                    Console.WriteLine("kod för banan: 300 ");
                    Console.WriteLine("kod för Äpple: 500 ");
                    Console.WriteLine("kommando\n<productid> <amount> för att betala: pay");
                    string komman = Console.ReadLine();

                    if (komman == "pay") break;
                    string[] parts = komman.Split(' ');

                    if (parts.Length == 2 )
                    {
                         success = int.TryParse(parts[0], out productId);
                         success = int.TryParse(parts[1], out amount);
                    }
                    if(success == false)
                    {
                        Console.WriteLine("Fel kommando");
                        Console.ReadKey();
                        continue; 
                    }
                    foreach (Product product in listOfProducts)
                    {
                        if (product.ProductId == productId)
                        {
                            ShopItem shopItem = new ShopItem(product, amount);

                            shoppingList.Add(shopItem);

                        }
                    }
                    
                }



            ReceiptHandler.CreateReceipt();
            ReceiptHandler.UpdateReceipt (shoppingList.ToArray());

           
        }
    }
}
