using Point_of_Sale;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Point_of_Sale
{
    internal class StockManager
    {

        string filepathInventory = "../../../inventory.txt";
        static string filepathCart = "../../../receipt.txt";

        public StockManager() { 
            initializeInventory();
        }

        private void initializeInventory()
        {

            List<Product> gameProducts = new List<Product>()
            {
                new Product("Hollow Knight", "Metroidvania", "Fun game about bugs!", 14.99m),
                new Product("Palworld", "Open World", "GTA Pokemon", 29.99m),
                new Product("Crash Bandicoot 4", "Platformer", "Jump on boxes and die", 19.99m),
                new Product("Tekken 8", "3D Fighter", "Throw your son in a volcano", 69.99m),
                new Product("Persona 3 Reload", "JRPG", "Stay up late after school", 69.99m),
                new Product("League of Legends", "MOBA", "Torture", 100000m),
                new Product("Monster Hunter Rise", "JRPG", "Beat up mean animals", 39.99m),
                new Product("Spiderman Remastered", "Open World", "Vigilante game", 19.99m),
                new Product("Baldurs Gate 3", "RPG", "Worms in my brain", 59.99m),
                new Product("Among US", "Social Deduction", "Drama", 20m),
                new Product("Psychonauts 2", "Platformer", "I miss summer camp", 20.39m),
                new Product("UNO", "Card Game", "Classic - Test Your Friendships", 9.99m)
            };


            // export product list to text file
            if (File.Exists(filepathInventory) == false)
            {
            StreamWriter tempWriter = new StreamWriter(filepathInventory);

                foreach (Product product in gameProducts)
                {
                    tempWriter.WriteLine(product);
                }

                tempWriter.Close();

            }

                
        }

        public string getGameByName(string newGameName)
        {
            //Reading file & return game details
                
            StreamReader reader = new StreamReader(filepathInventory);
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    reader.Close();
                    return "All games are sold out!";
                    
                }
                else
                {
                    if (line.Contains(newGameName))
                    {
                        reader.Close ();
                        return line;
                    }
                }
            }
            
        }

        // receipt maker
        public static void addPurchasedGames(List<Product> cartItems, decimal subTotal, string paymentType, decimal change)
        {
            //adding game to receipt
            
            StreamWriter writer = new StreamWriter(filepathCart);
            string[] receiptArray = receipt(subTotal, paymentType, change);
            foreach(string item in receiptArray)
            {
                writer.WriteLine(item);
            }

            writer.WriteLine("");
            foreach (Product game in cartItems)
            {

                //name
                //category
                //description
                //price
                
                writer.WriteLine(game.DisplayString());
            }
            writer.Close();
        }

        public static string[] receipt(decimal subTotal, string paymentType, decimal change)
        {
            subTotal = Math.Round(subTotal, 2);
            decimal salesTax = Math.Round(subTotal * 0.06m, 2);
            decimal total = Math.Round(subTotal + salesTax, 2);


            string[] newReceipt;
            if (change >= 0) 
            {
                newReceipt = new String[5];
                
            } 
            else
            {
                newReceipt = new String[4];
                
            }

            Console.WriteLine($"Your Subtotal is ${subTotal}");
            newReceipt[0] = $"Your Subtotal is ${subTotal}";

            Console.WriteLine($"Your Sales Tax is ${salesTax}");
            newReceipt[1] = $"Your Sales Tax is ${salesTax}";

            Console.WriteLine($"Your Total is ${total}");
            newReceipt[2] = $"Your Total is ${total}";

            Console.WriteLine($"You paid with {paymentType}");
            newReceipt[3] = $"You paid with {paymentType}";


            if (change >= 0)
            {
                Console.WriteLine($"Your change is ${change}");
                newReceipt[4] = $"Your change is ${change}";
            }

            return newReceipt;

        }


    }
}
