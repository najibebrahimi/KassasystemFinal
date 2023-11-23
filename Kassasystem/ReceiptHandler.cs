using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class ReceiptHandler
    {
        private static int receiptID;

        public static void CreateReceipt()
        {
           
            string filePath = $"../../../receipt{DateTime.Today.ToString("d")}.txt";
            
            if(File.Exists(filePath))
            {
                return;
            }
            File.Create(filePath).Close();
               
        }

        public static void UpdateReceipt(ShopItem[] list)
        
        {
            double total = 0;
            string title = "\nKvitto " + $"{DateTime.Now}\n";
            string productText = string.Empty;

            foreach (ShopItem item in list)
            {


                productText += (item.Amount + " x " + item.Produkt.Name + ": " + (item.Produkt.Price * item.Amount) + "\n");
                total += (item.Produkt.Price * item.Amount);
            }
            string content = title + productText + $"Total: {total}";
            File.AppendAllText($"../../../receipt{DateTime.Today.ToString("d")}.txt", content);
            
        }

    }

    
}
