// authors: Victor, Dominic, Rod
// topic: C#.NET Midterm Project

using Point_of_Sale;

Console.WriteLine("--- Welcome to Game Ville! ---");

//Initialize our list of games and runprogram loop
List<Product> gameProducts = StockManager.initializeInventory();
bool runProgram = true;

//Main Program Loop
while (runProgram)
{

    //initialize our cart list, shopping loop, and our reciept values
    List<Product> cart = new List<Product>();
    decimal subTotal = 0;
    decimal total = 0;
    bool shopping = true;

    //Check to see if we had issues converting our .txt file over to our product objects
    if(gameProducts.Count <= 0)
    {
        Console.WriteLine("Sorry, we are either out of our inventory or facing errors. Try again later. Goodbye!");
        break;
    }

    //Loop our main shopping function
    while (shopping)
    {

        //Rescan our inventory in for repeat loops
        gameProducts = StockManager.initializeInventory();

        //Restart our line total at 0 for each new line
        decimal lineTotal = 0;

        //display our store to our users
        Console.WriteLine(String.Format("{0, -6} {1, -25} | {2, -30} | {3, -35} | {4, 10}", $"Item#", $"Game", "Category", "Description", "Price"));
        Console.WriteLine("=====================================================================================================================");

        //loop through our product list to show each product and its index
        for (int i = 0; i < gameProducts.Count; i++)
        {
            Console.WriteLine($"{gameProducts[i].DisplayString(i)}");
        }

        //Get the user input for the index of which game they would like to purchase
        Console.Write("\nWhat game would you like to purchase?: ");
        int choice = (Validator.getValidInt(1, gameProducts.Count)) - 1;

        //Loop to make sure the game the user has choosen is not out of stock!
        //May be redundant after recent changes to updating inventory after each item is added to cart
        while(true)
        {
            if (gameProducts[choice].quantity == 0)
            {
                Console.WriteLine("Sorry that game is out of stock! Please choose another!");
                Console.Write("\nWhat game would you like to purchase?: ");
                choice = (Validator.getValidInt(1, gameProducts.Count)) - 1;
                continue;
            }
            break;
        }


        //Gets user input on quanity of items they would like to add to the cart
        Console.Write("\nHow many items would you like to purchase?: ");
        int quantity = Validator.getValidPositiveInt();


        //Loop to make sure the quantity of items added to cart is not greater than quantity in stock
        while(true)
        {
            if (gameProducts[choice].quantity - quantity < 0) 
            {
                if (gameProducts[choice].quantity == 1)
                {
                    Console.WriteLine($"Sorry we only have {gameProducts[choice].quantity} copy left, here you go!");
                    quantity = 1;
                    break;
                }
                else
                {
                    Console.WriteLine($"Sorry we only have {gameProducts[choice].quantity} copies left.");
                    Console.Write("\nHow many items would you like to purchase?: ");
                    quantity = Validator.getValidPositiveInt();
                    continue;
                }
            }
            break;
        }


        //adds each item purchased to the users cart and removes that many from the store inventory
        for (int i = 0; i < quantity; i++)
        {
            cart.Add(gameProducts[choice]);
            gameProducts[choice].quantity --;

            lineTotal += gameProducts[choice].price;
        }


        //displays line total for the user and adds to subtotal
        Console.WriteLine($"\nYour line total for these items is ${Math.Round(lineTotal, 2)}");
        subTotal += lineTotal;


        //displays the users current cart back to them
        Console.WriteLine();
        Console.WriteLine("Shopping Cart: ");
        for (int c = 0; c < cart.Count; c++)
        {
            Console.WriteLine(String.Format("{0, -25} {1, 10}", $"{cart[c].name}", cart[c].price));
        }


        //Ask the user if they would like to add more items to their cart
        shopping = Validator.getContinue("\nWould you like to keep shopping?");
        Console.Clear();

        //update store inventory
        StockManager.updateInventory(gameProducts);

    }



    //Calculate and display the users total back to them
    total = subTotalMath(subTotal);
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();

    //initialize change and payment type variables for future use
    decimal change = -1;
    string paymentType = "";


    //Display a menu to the user for different payment types
    //and get the users input for which payment type theyd like to use
    Console.WriteLine("What is your payment type?");
    Console.WriteLine("1- Cash");
    Console.WriteLine("2- Check");
    Console.WriteLine("3- Credit");
    int paymentChoice = Validator.getValidInt(1, 3);


    //
    if (paymentChoice == 1)
    {
        paymentType += "Cash ";
        Console.WriteLine($"\nYour total was ${total}");
        Console.WriteLine("\nPlease enter your cash ammount: ");
        decimal cash = Validator.getValidDecimal();
        while (cash < total)
        {
            Console.WriteLine("Sorry that isn't enough payment, try again: ");
            cash = Validator.getValidDecimal(); //returns a decimal
        }
        change = cashPayment(cash, total);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
    //
    //  FLAGGED NOT DONE
    //
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

    // TODO: 
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

    // Generates text file with receipt and displays the receipt to the console
    StockManager.addPurchasedGames(cart ,subTotal, paymentType, change) ; 

    //Asks the user if theyd like to start another cart
    runProgram = Validator.getContinue("Would you like to shop again?");

    //If not, display a goodbye message
    if(!runProgram) Console.WriteLine("Thanks for shopping at the Game Ville!");

    //Update the stores inventory to match what has just been purchased
    StockManager.updateInventory(gameProducts);

}



//Method to calculate and display subtotal, sales tax, and total
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


//Method to determine how much change to give back to the user after cash payment
static decimal cashPayment(decimal cash, decimal total)
{
    decimal change = Math.Round(cash - total, 2);

    //Console.WriteLine($"You paid ${cash}, and your total was ${total}!");
    //Console.WriteLine($"Here is your change! ${change}");

    return change;
}