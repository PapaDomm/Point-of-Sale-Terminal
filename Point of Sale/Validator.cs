using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale
{
    internal class Validator
    {
        //NUMBERS

        //ints
        public static int getValidInt()
        {
            int num;
            while(!int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Please enter a valid input: ");
            }

            return num;
        }

        public static int getValidInt(int lowerBound, int upperBound)
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num) && (num < lowerBound || num > upperBound))
            {
                Console.Write($"Please enter a valid input of {lowerBound} - {upperBound}: ");
            }

            return num;
        }

        public static int getValidPositiveInt()
        {
            int num;
            while(!int.TryParse(Console.ReadLine(), out num) && num < 0)
            {
                Console.Write("Please enter a valid positive input: ");
            }

            return num;
        }

        public static int getValidNegativeInt()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num) && num > 0)
            {
                Console.Write("Please enter a valid negative input: ");
            }

            return num;
        }

        //doubles
        public static double getValidDouble()
        {
            double num;
            while (!double.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Please enter a valid input: ");
            }

            return num;
        }

        public static double getValidDouble(double lowerBound, double upperBound)
        {
            double num;
            while (!double.TryParse(Console.ReadLine(), out num) && (num < lowerBound || num > upperBound))
            {
                Console.Write($"Please enter a valid input of {lowerBound} - {upperBound}: ");
            }

            return num;
        }

        public static double getValidPositiveDouble()
        {
            double num;
            while (!double.TryParse(Console.ReadLine(), out num) && num < 0)
            {
                Console.Write("Please enter a valid positive input: ");
            }

            return num;
        }

        public static double getValidNegativeDouble()
        {
            double num;
            while (!double.TryParse(Console.ReadLine(), out num) && num > 0)
            {
                Console.Write("Please enter a valid negative input: ");
            }

            return num;
        }

        //floats
        public static float getValidFloat()
        {
            float num;
            while (!float.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Please enter a valid input: ");
            }

            return num;
        }

        public static float getValidFloat(float lowerBound, float upperBound)
        {
            float num;
            while (!float.TryParse(Console.ReadLine(), out num) && (num < lowerBound || num > upperBound))
            {
                Console.Write($"Please enter a valid input of {lowerBound} - {upperBound}: ");
            }

            return num;
        }

        public static float getValidPositiveFloat()
        {
            float num;
            while (!float.TryParse(Console.ReadLine(), out num) && num < 0)
            {
                Console.Write("Please enter a valid positive input: ");
            }

            return num;
        }

        public static float getValidNegativeFloat()
        {
            float num;
            while (!float.TryParse(Console.ReadLine(), out num) && num > 0)
            {
                Console.Write("Please enter a valid negative input: ");
            }

            return num;
        }

        //decimals
        public static decimal getValidDecimal()
        {
            decimal num;
            while (!decimal.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Please enter a valid input: ");
            }

            return num;
        }

        public static decimal getValidDecimal(decimal lowerBound, decimal upperBound)
        {
            decimal num;
            while (!decimal.TryParse(Console.ReadLine(), out num) && (num < lowerBound || num > upperBound))
            {
                Console.Write($"Please enter a valid input of {lowerBound} - {upperBound}: ");
            }

            return num;
        }

        public static decimal getValidPositiveDecimal()
        {
            decimal num;
            while (!decimal.TryParse(Console.ReadLine(), out num) && num < 0)
            {
                Console.Write("Please enter a valid positive input: ");
            }

            return num;
        }

        public static decimal getValidNegativeDecimal()
        {
            decimal num;
            while (!decimal.TryParse(Console.ReadLine(), out num) && num > 0)
            {
                Console.Write("Please enter a valid negative input: ");
            }

            return num;
        }

        //CONTINUES
        public static bool getContinue()
        {
            Console.Write("Would you like to continue?(Y/N): ");
            string answer = Console.ReadLine().ToLower().Trim();
            while (answer != "y" && answer != "n")
            {
                Console.Write("\nPlease enter a valid input of (Y/N): ");
                answer = Console.ReadLine().ToLower().Trim();
            }

            if (answer == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool getContinue(string message)
        {
            Console.Write($"{message}(Y/N): ");
            string answer = Console.ReadLine().ToLower().Trim();
            while (answer != "y" && answer != "n")
            {
                Console.Write("\nPlease enter a valid input of (Y/N): ");
                answer = Console.ReadLine().ToLower().Trim();
            }

            if (answer == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool getContinue(string message, string val1, string val2)
        {
            Console.Write($"{message}({val1}/{val2}): ");
            string answer = Console.ReadLine().ToLower().Trim();
            while (answer != "y" && answer != "n")
            {
                Console.Write($"\nPlease enter a valid input of ({val1}/{val2}): ");
                answer = Console.ReadLine().ToLower().Trim();
            }

            if (answer == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Choice Validation
        public static string getValidChoice(List<string> strings)
        {
            string choice = Console.ReadLine().ToLower().Trim();
            while(!strings.Contains(choice))
            {
                Console.Write("\nPlease enter a valid input: ");
                choice = Console.ReadLine().ToLower().Trim();
            }

            return choice;
        }
    }
}
