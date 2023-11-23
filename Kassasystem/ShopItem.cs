using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public class ShopItem
    {
        public Product Produkt { get; set; }
        public int Amount { get; set; }

        public ShopItem(Product produkt, int amount)
        {
            Produkt = produkt;
            Amount = amount;
        }

    }
    
}
