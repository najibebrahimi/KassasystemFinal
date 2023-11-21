using System.Collections.Generic;

namespace Kassasystem
{
    struct Produkt
    {
        public string command;
        public string name;
        public double pris;
        public string unit;
    }
    struct Shop
    {
        public Produkt produkt;
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
            Produkt[] list = CreateTextFile();

            List<Shop> list2 = new List<Shop>();
            do
            {
                Console.Clear();
                
                foreach (var item in list2)
                {
                    Console.WriteLine(item.amount + " x " + item.produkt.name + ": " + (item.produkt.pris * item.amount));
                }
                Console.WriteLine("kommando\n<productid> <amount>\npay");
                string komman = Console.ReadLine();

                if (komman == "pay") break;

                string[] gamma = komman.Split(' ');


                foreach (Produkt item in list)
                {
                    if (item.command == gamma[0])
                    {
                        Shop p = new Shop();
                        p.produkt = item;
                        p.amount = Int32.Parse(gamma[1]);
                        list2.Add(p);
                    }
                }

            } while (true); 

            Kvitto(list2.ToArray());
        }

        static Produkt[] CreateTextFile()
        {
            
            string[] list = File.ReadAllLines("../../../products.txt");
            

            Produkt[] p = new Produkt[list.Length];
            int i = 0;
            foreach (string s in list)
            {
                string[] line = s.Split(',');
                Produkt pr = new Produkt();
                pr.command = line[0].ToString();
                pr.name = line[1].ToString();
                pr.pris = double.Parse(line[2].ToString());
                pr.unit = line[3].ToString();

                p[i++] = pr;
            }
            return p;
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
                        writer.WriteLine(item.amount + " x " + item.produkt.name + ": " + (item.produkt.pris * item.amount));
                        
                        totalPris += (int)(item.produkt.pris * item.amount);
                    }
                }
                
                writer.WriteLine("Total: " + totalPris);
            }
        }
    }
}