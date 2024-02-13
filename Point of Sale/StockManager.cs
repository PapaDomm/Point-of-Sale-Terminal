using Point_of_Sale;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Point_of_Sale
{
    internal class StockManager
    {

        //initialize our filepaths and our out of stock product list
        public static string filepathInventory = "../../../inventory.txt";
        public static string filepathCart = "../../../receipt.txt";
        public static List<Product> storeProducts = new List<Product>();


        //method to initialize our inventory, update our games list, and update our out of stock list
        public static List<Product> initializeInventory()
        {
            //initialize our game product list that will be used throughout the main  program
            List<Product> gameProducts  = new List < Product >();

            //creates a default list of games if no inventory file exists
            if (!File.Exists(filepathInventory))
            {

                gameProducts = getDefaulInventory();

                StreamWriter tempWriter = new StreamWriter(filepathInventory);

                foreach (Product product in gameProducts)
                {
                    tempWriter.WriteLine(product.productToInventory());
                }

                tempWriter.Close();

            }

            //if an inventory file does exist, read that file and create our games objects and list
            else
            {
                StreamReader tempReader = new StreamReader(filepathInventory);
                storeProducts = new List<Product>();

                //Loop to go through the entire file for all objects
                while (true)
                {
                    //try/catch for possible text file corruptions
                    try
                    {
                        string line = tempReader.ReadLine();

                        //If our line has text, decipher it
                        if (line != null)
                        {
                            //.txt file should be formated with | to seperate object properties
                            string[] newObj = line.Split("|");

                            //if object property == 0 then put the object in our out of stock list
                            if (int.Parse(newObj[4]) <= 0)
                            {
                                storeProducts.Add(new Product(newObj[0], newObj[1], newObj[2], decimal.Parse(newObj[3]), int.Parse(newObj[4])));
                                continue;
                            }

                            //else, add the product to our main games product list
                            else
                            {
                                gameProducts.Add(new Product(newObj[0], newObj[1], newObj[2], decimal.Parse(newObj[3]), int.Parse(newObj[4])));
                            }
                        }

                        //break the loop when we're out of lines
                        else { break; }
                    }

                    //if there is an error, possibly send error message to user
                    catch (Exception e)
                    {
                        //Console.WriteLine("Inventory List Error, Please make sure the inventory file is not corrupted!");
                    }

                }

                //close our reader, causes bugs if this is not their when updating list
                tempReader.Close();
            }

            //return our main list for store inventory
            return gameProducts;

                
        }

        //update the inventory for the store after shopping
        public static void updateInventory(List<Product> gameProducts)
        {
            StreamWriter tempWriter = new StreamWriter(filepathInventory);

            //adds all games not out of stock to the file
            foreach (Product product in gameProducts)
            {
                tempWriter.WriteLine(product.productToInventory());
            }

            //adds all out of stock games to the file
            foreach (Product product in storeProducts)
            {
                tempWriter.WriteLine(product.productToInventory());
            }

            tempWriter.Close();
        }

        //our default inventory list
        public static List<Product> getDefaulInventory()
        {
            List<Product> gameProducts = new List<Product>()
            {
                new Product("Hollow Knight", "Metroidvania", "Fun game about bugs!", 14.99m, 10),
                new Product("Palworld", "Open World", "GTA Pokemon", 29.99m, 5),
                new Product("Crash Bandicoot 4", "Platformer", "Jump on boxes and die", 19.99m, 15),
                new Product("Tekken 8", "3D Fighter", "Throw your son in a volcano", 69.99m, 20),
                new Product("Persona 3 Reload", "JRPG", "Stay up late after school", 69.99m, 5),
                new Product("League of Legends", "MOBA", "Torture", 100000m, 1),
                new Product("Monster Hunter Rise", "JRPG", "Beat up mean animals", 39.99m, 13),
                new Product("Spiderman Remastered", "Open World", "Vigilante game", 19.99m, 19),
                new Product("Baldurs Gate 3", "RPG", "Worms in my brain", 59.99m, 24),
                new Product("Among US", "Social Deduction", "Drama", 20m, 2),
                new Product("Psychonauts 2", "Platformer", "I miss summer camp", 20.39m, 11),
                new Product("UNO", "Card Game", "Classic - Test Your Friendships", 9.99m, 8)
            };

            return gameProducts;
        }


        // receipt maker
        public static void addPurchasedGames(List<Product> cartItems, decimal subTotal, string paymentType, decimal change)
        {
            //adding game to receipt
            
            StreamWriter writer = new StreamWriter(filepathCart);
            string[] receiptArray = receipt(subTotal, paymentType, change);
            
            writer.WriteLine("\t--- GameVille Reciept ---");
            writer.WriteLine();
            foreach (Product game in cartItems)
            {

                //name
                //category
                //description
                //price
                
                writer.WriteLine(game.DisplayString());
            }

            writer.WriteLine();
            foreach (string item in receiptArray)
            {
                writer.WriteLine(string.Format("{0, 36}", item));
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
                newReceipt = new String[6];
                
            } 
            else
            {
                newReceipt = new String[5];
                
            }

            Console.WriteLine($"Your Subtotal is ${subTotal}");
            newReceipt[0] = $"Your Subtotal is ${subTotal}";

            Console.WriteLine($"Your Sales Tax is ${salesTax}");
            newReceipt[1] = $"Your Sales Tax is ${salesTax}";

            Console.WriteLine($"Your Total is ${total}");
            newReceipt[2] = $"Your Total is ${total}";

            Console.WriteLine($"You paid with {paymentType}");
            newReceipt[3] = $"You paid with {paymentType}";

            Console.WriteLine();
            newReceipt[4] = "";
            if (change >= 0)
            {
                Console.WriteLine($"Your change is ${change}");
                newReceipt[5] = $"Your change is ${change}";
            }

            return newReceipt;

        }
        

    }
}
