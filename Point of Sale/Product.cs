using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Point_of_Sale
{
    internal class Product
    {
        // add properties
        public string name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }

        public int quantity { get; set; }

        //constructors
        public Product() 
        {
            name = "GoldenNuggets";
            category = "jewel";
            description = "18karat";
            price = 1000000m;
            quantity = 0;
        }
        public Product(
            string newName, 
            string newCategory, 
            string newDescription, 
            decimal newPrice,
            int newQuantity)
        {
            name = newName;
            category = newCategory;
            description = newDescription;
            price = newPrice;
            quantity = newQuantity;
        }

        //methods
        public string DisplayString() // receipt
        {
            string game = String.Format("{0, -25} {1, 10}",$"{name}",  $"${price}");
            return game;
        }

        
        public string DisplayString(int i) // console
        {
            string game = String.Format("{0, -6} {1, -25} | {2, -30} | {3, -35} | {4, 10}", $"{i + 1}- ", $"{name}", $"{category}", $"{description}", $"{price}");
            return game;
        }

        public string productToInventory()//.txtfile
        {
            string game = $"{name}|{category}|{description}|{price}|{quantity}";
            return game;
        }
    }
}
