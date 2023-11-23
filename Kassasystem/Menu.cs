using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem
{
    public static class Menu
    {
        public static void MainMenu()
        {
            string myOptions;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to my app!");
                Console.WriteLine("Option 1. New customer");
                Console.WriteLine("Option 0. exit");
                Console.Write("Option: ");
                myOptions = Console.ReadLine();
                switch (myOptions)
                {
                    case "1":
                        // Istället för att anropa program så kan man anropa CustomerHandler klassen
                        //Program.NewCustomer();
                        CustomerHandler.NewCustomer();
                        break;
                }

            } while (myOptions != "0");
        }
    }
}
