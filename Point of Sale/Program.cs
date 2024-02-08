// authors: Victor, Dominic, Rod
// topic: C#.NET Midterm Project

using Point_of_Sale;

Console.WriteLine("--- Welcome to Game Ville! ---");

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

bool runProgram = true;
bool shopping = true;


while (runProgram)
{

    List<Product> cart = new List<Product>();
    decimal subTotal = 0;
    decimal total = 0;

    while (shopping)
    {


        decimal lineTotal = 0;
        Console.WriteLine(String.Format("{0, -6} {1, -25} | {2, -30} | {3, -35} | {4, 10}", $"Item#", $"Game", "Category", "Description", "Price"));
        Console.WriteLine("=====================================================================================================================");
        for (int i = 0; i < gameProducts.Count; i++)
        {
            Console.WriteLine($"{gameProducts[i].DisplayString(i)}");
        }


        Console.Write("\nWhat game would you like to purchase?: ");
        int choice = (Validator.getValidInt(1, gameProducts.Count)) - 1;

        Console.Write("\nHow many items would you like to purchase?: ");
        int quantity = Validator.getValidPositiveInt();
        for (int i = 0; i < quantity; i++)
        {
            cart.Add(gameProducts[choice]);
            lineTotal += gameProducts[choice].price;
        }

        Console.WriteLine($"\nYour line total for these items is ${Math.Round(lineTotal, 2)}");
        subTotal += lineTotal;

        Console.WriteLine();
        for (int c = 0; c < cart.Count; c++)
        {
            Console.WriteLine(String.Format("{0, -25} {1, 10}", $"{cart[c].name}", cart[c].price));
        }

        shopping = Validator.getContinue("\nWould you like to keep shopping?");
        Console.Clear();
    }



    total = subTotalMath(subTotal);
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();

    decimal change = -1;
    string paymentType = "";

    Console.WriteLine("What is your payment type?");
    Console.WriteLine("1- Cash");
    Console.WriteLine("2- Check");
    Console.WriteLine("3- Credit");
    int paymentChoice = Validator.getValidInt(1, 3);

    if (paymentChoice == 1)
    {
        paymentType += "Cash ";
        Console.WriteLine($"\nYour total was ${total}");
        Console.WriteLine("\nPlease enter your cash ammount: ");
        decimal cash = Validator.getValidDecimal();
        while (cash < total)
        {
            Console.WriteLine("Sorry that isn't enough payment, try again: ");
            cash = Validator.getValidDecimal();
        }
        change = cashPayment(cash, total);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
    else if (paymentChoice == 2)
    {
        paymentType += "Check ";
        Console.WriteLine($"\nYour total was ${total}");
        Console.WriteLine("\nPlease enter the check number: ");
        //regular expression required
        string check = "";
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
    else
    {
        paymentType += "Credit ";
        Console.WriteLine($"\nYour total was ${total}");
        //regular expression required

        Console.WriteLine("\nPlease enter your credit card number: ");
        Validator.getValidCreditCardNumber(Console.ReadLine());

        Console.WriteLine("\nPlease enter your credit card expiration date: ");
        Validator.getValidExpiration(Console.ReadLine());

        Console.WriteLine("\nPlease enter you credit card CVV: ");
        Validator.getValidCVV(Console.ReadLine());

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }


    receipt(subTotal, paymentType, change);
    runProgram = Validator.getContinue("Would you like to shop again?");
    if(!runProgram) Console.WriteLine("Thanks for shopping at the Game Ville!");

}

































static decimal subTotalMath(decimal subTotal)
{
    subTotal = Math.Round(subTotal, 2);
    decimal salesTax = Math.Round(subTotal * 0.06m, 2);
    decimal total = Math.Round(subTotal + salesTax, 2);

    Console.WriteLine($"Your Subtotal is ${subTotal}");
    Console.WriteLine($"Your Sales Tax is ${salesTax}");
    Console.WriteLine($"Your Total is ${total}");

    return total;
}

static void receipt(decimal subTotal, string paymentType, decimal change)
{
    subTotal = Math.Round(subTotal, 2);
    decimal salesTax = Math.Round(subTotal * 0.06m, 2);
    decimal total = Math.Round(subTotal + salesTax, 2);

    Console.WriteLine($"Your Subtotal is ${subTotal}");
    Console.WriteLine($"Your Sales Tax is ${salesTax}");
    Console.WriteLine($"Your Total is ${total}");
    Console.WriteLine($"You paid with {paymentType}");
    if (change >= 0)
    {
        Console.WriteLine($"Your change is ${change}");
    }
}


static decimal cashPayment(decimal cash, decimal total)
{
    decimal change = Math.Round(cash - total, 2);

    //Console.WriteLine($"You paid ${cash}, and your total was ${total}!");
    //Console.WriteLine($"Here is your change! ${change}");

    return change;
}