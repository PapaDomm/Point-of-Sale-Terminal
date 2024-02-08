using Point_of_Sale;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale
{
    internal class StockManager
    {

        string filepath = "../../../inventory.txt";

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
            if (File.Exists(filepath) == false)
            {
            StreamWriter tempWriter = new StreamWriter(filepath);

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
                
            StreamReader reader = new StreamReader(filepath);
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


    }
}
