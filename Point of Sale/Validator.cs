using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                Console.Write("\nPlease enter a valid input: ");
            }

            return num;
        }

        public static int getValidInt(int lowerBound, int upperBound)
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num) || (num < lowerBound || num > upperBound))
            {
                Console.Write($"\nPlease enter a valid input of {lowerBound} - {upperBound}: ");
            }

            return num;
        }

        public static int getValidPositiveInt()
        {
            int num;
            while(!int.TryParse(Console.ReadLine(), out num) || num < 0)
            {
                Console.Write("\nPlease enter a valid positive input: ");
            }

            return num;
        }

        public static int getValidNegativeInt()
        {
            int num;
            while (!int.TryParse(Console.ReadLine(), out num) || num > 0)
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
                Console.Write("\nPlease enter a valid input: ");
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
            Console.Write("\nWould you like to continue?(Y/N): ");
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
            Console.Write($"\n{message}(Y/N): ");
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
            Console.Write($"\n{message}({val1}/{val2}): ");
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


        //Regex
        public static void getValidCheckNumber(string checkNumber)
        {
            checkNumber = checkNumber.Trim().Replace(" ", "");

            Regex checkPatern = new Regex(@"^[0-9]{3,6}$");

            Match checkMatch = checkPatern.Match(checkNumber);

            while(!checkMatch.Success)
            {
                Console.Write("\nPlease enter a valid Check Number: ");
                checkNumber = Console.ReadLine().Trim().Replace(" ", "");
                checkMatch = checkPatern.Match(checkNumber);
            }
        }


        public static void getValidCreditCardNumber(string creditCardNumber)
        {
            creditCardNumber = creditCardNumber.Trim().Replace(" ", "").Replace("-", "");

            bool isCreditCard = isMatchCC(creditCardNumber);

            while(!isCreditCard)
            {
                Console.Write("\nPlease enter a valid Credit Card Number: ");
                creditCardNumber = Console.ReadLine().Trim().Replace(" ", "").Replace("-", "");
                isCreditCard = isMatchCC(creditCardNumber);
            }         
        }

        public static void getValidCVV(string ccCVV)
        {
            ccCVV = ccCVV.Trim().Replace(" ", "");

            Regex ccCVVPattern = new Regex(@"^[0-9]{3,4}$");

            Match ccCVVMatch = ccCVVPattern.Match(ccCVV);

            while (!ccCVVMatch.Success)
            {
                Console.Write("\nPlease enter a valid CVV number (xxx or xxxx): ");
                ccCVV = Console.ReadLine().Trim().Replace(" ", "");
                ccCVVMatch = ccCVVPattern.Match(ccCVV);
            }
        }

        public static void getValidExpiration(string ccExpiration)
        {
            ccExpiration = ccExpiration.Trim();

            Regex ccExp = new Regex(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$");

            Match ccExpMatch = ccExp.Match(ccExpiration);

            while (!ccExpMatch.Success)
            {
                Console.Write("\nPlease enter a valid Expiration Date (xx/xx): ");
                ccExpiration = Console.ReadLine().Trim();
                ccExpMatch = ccExp.Match(ccExpiration);
            }
        }

        public static bool isMatchCC(string creditCardNumber)
        {
            Regex visaccPattern = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?");
            Regex masterccPatern = new Regex(@"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$");
            Regex americanccPatern = new Regex(@"^3[47][0-9]{13}$ ");
            Regex dinersccPatern = new Regex(@"^3(?:0[0-5]|[68][0-9])[0-9]{11}$");
            Regex discoverccPatern = new Regex(@"^6(?:011|5[0-9]{2})[0-9]{12}$");
            Regex jcbccPatern = new Regex(@"^(?:2131|1800|35\d{3})\d{11}$");

            Match visaMatch = visaccPattern.Match(creditCardNumber);
            Match masterMatch = masterccPatern.Match(creditCardNumber);
            Match americanMatch = americanccPatern.Match(creditCardNumber);
            Match dinersMatch = dinersccPatern.Match(creditCardNumber);
            Match discoverMatch = discoverccPatern.Match(creditCardNumber);
            Match jcbMatch = jcbccPatern.Match(creditCardNumber);

            if(!visaMatch.Success && !masterMatch.Success && !americanMatch.Success && !dinersMatch.Success && !discoverMatch.Success && !jcbMatch.Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
