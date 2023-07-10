
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

decimal itemTotal = 0;//declaring and initializing item total variable
bool keepGoing = false;//declaring and initialzing keepgoing to true do that the while loop below will run
string moneyEntered; //declaring var to store user input for money entered
decimal totalMoneyEntered = 0;//declaring var to store total for the money entered
decimal totalDue; //declaring variable for the total due
decimal change = 0; // declaring and initializing variable to hold value of change due to customer if any
int[] currency = new int[10];//array to be used to calculate how to give change in greedy algorhythm
string Path1; // declaring string var to hold user input 
bool payWithCard = false;//declaring boolean and initailizing to false
string cardNum;//declaring variable to store user input to be used for validating card#
bool cashBack = false;//declaring boolean
string cashBackAmount; //declaring var for how much a user may want back
string accountNum; //declaring variable for account number
Random rnd = new Random();
string transactionNum = rnd.Next(1, 1000).ToString();
string transactionDate = DateTime.Now.ToString("MMM-d-yy");
string transactionTime = DateTime.Now.ToString("T");
string paymentCashAmount = "NULL";
string cardVendor = "NULL";
string cardAmount = "NULL";
string paymentCardVendorAmount;
string changeGiven;
string cashOrCard;


//initialzing all variables in struct till 
till pennies;
pennies.denomination = "pennies";
pennies.value = 0.01m;
pennies.count = 5;
till nickels;
nickels.denomination = "nickles";
nickels.value = 0.05m;
nickels.count = 5;
till dimes;
dimes.denomination = "dimes";
dimes.value = 0.1m;
dimes.count = 5;
till quarters;
quarters.denomination = "quarters";
quarters.value = 0.25m;
quarters.count = 5;
till ones;
ones.denomination = "ones";
ones.value = 1;
ones.count = 5;
till fives;
fives.denomination = "fives";
fives.value = 5;
fives.count = 5;
till tens;
tens.denomination = "tens";
tens.value = 10;
tens.count = 5;
till twenties;
twenties.denomination = "twenties";
twenties.value = 20;
twenties.count = 5;
till fifties;
fifties.denomination = "fifties";
fifties.value = 50;
fifties.count = 5;
till hundreds;
hundreds.denomination = "hundreds";
hundreds.value = 100;
hundreds.count = 5;

Console.WriteLine("******************* R&Z  KIOSK **********************");//output
Console.WriteLine("Please chose one: \nWill you be continuing as a customer or employee?");//prompt to user for input
Path1 = Console.ReadLine().ToLower();//storing user data as all lowercase

while (Path1 != "customer" && Path1 != "employee")//input validation
{
    Console.WriteLine("ERROR: INVALID INPUT\nPLEASE ENTER 'CUSTOMER' OR 'EMPLOYEE'");
    Console.WriteLine("Please chose one: \nWill you be continuing as a customer or employee?");//prompt to user for input
    Path1 = Console.ReadLine().ToLower();
}
if (Path1 == "customer")
{
    keepGoing = true;
}
while (Path1 == "employee")//if this condition is true, execute code below
{
    keepGoing = false;//set keepgoing to false so the rest of the code doesn't run
    Console.Clear(); //makes it look better

    //OUTPUT
    Console.WriteLine("Welcome to the home screen for employees. Below is a real-time till count.");
    Console.WriteLine("------------------------------------------------------------------------------");
    Console.WriteLine("Pennies = {0} ", pennies.count);
    Console.WriteLine("Nickels = {0} ", nickels.count);
    Console.WriteLine("Dimes   = {0} ", dimes.count);
    Console.WriteLine("Quarters= {0} ", quarters.count);
    Console.WriteLine("Ones    = {0} ", ones.count);
    Console.WriteLine("Fives   = {0} ", fives.count);
    Console.WriteLine("Tens    = {0} ", tens.count);
    Console.WriteLine("Twenties= {0} ", twenties.count);
    Console.WriteLine("Fifties= {0} ", fifties.count);
    Console.WriteLine("Hundreds = {0} ", hundreds.count);
    Console.WriteLine("Enter Y to return to home page or N to exit the console"); //prompt for input

    Path1 = Console.ReadLine().ToString().ToLower();

    while (Path1 != "y" && Path1 != "n")//input validation
    {
        Console.WriteLine("Invalid input: Please enter 'Y' to return to homepage or 'N' to exit the console");
        Path1 = Console.ReadLine().ToString().ToLower();
    }
    if (Path1 == "y") 
    {
        keepGoing = true; //continue to homepage
        break;
    }
    else if(Path1 == "n")
    {
        goto cancelled; //go to camclled to exit the program
    }

 
}


Console.Clear(); //reset console to look better
//START PROGRAM
Console.WriteLine("Welcome to R&Z self checkout!");//output


while (keepGoing)//while this condition is true
{
    Console.Write("Please enter your item cost : ");//prompt to user for input
 itemInput://go to identifier for if input is invalid
    Path1 = Console.ReadLine();//storing user input


    try//will attempt to run followin gcode unless there are issues
    {
        if (decimal.Parse(Path1) > 0)
        {
            itemTotal += decimal.Parse(Path1);//converting and adding user data to previous value of itemnTotal
        }
        else if (decimal.Parse(Path1) <= 0) // input validation - ensuring user does not enter 0 number or negative 
        {
            Console.WriteLine("Invalid input: Please enter non-negative non-zero number"); 
            goto itemInput; //sends user back to where they can enter item cost at goto identifier itemInput
        }
        Console.WriteLine("Total due: {0}", itemTotal.ToString("C"));//output
        Console.Write("Enter another item? y/n : ");//prompt for input
        Path1 = Console.ReadLine().ToLower();


        while (Path1 != "y" && Path1 != "n")//input validation 
        {
            Console.WriteLine("Invalid input: Please enter 'y' for yes or 'n' for no");
            Console.Write("Enter another item? y/n : ");//prompt for input
            Path1 = Console.ReadLine().ToString().ToLower();
            Console.Clear();
        }
        if (Path1 == "y")
        {
            keepGoing = true;
            Console.Clear();
        }
        else if (Path1 == "n")
        {
            keepGoing = false;
            Console.Clear();
        }
    }
    catch (Exception error)//input validation - not in number format
    {
        Console.WriteLine("Invalid cost input!");
        Console.WriteLine("Please enter cost in the following format '1.50'");
        keepGoing = true;
    }

}


totalDue = itemTotal; //assigning totaldue to the value of itemTotal
Console.WriteLine("Your total today is " + itemTotal.ToString("C")); //output - getting a representation of itemtotal formatted as currency 
Console.WriteLine("______________________________________________________________");
Console.WriteLine("Please enter 1 if paying with CASH or 2 if paying with CARD");//prompt to user
Path1 = Console.ReadLine().ToLower();


while(Path1 != "1" && Path1 != "2")//input validation
{
    Console.WriteLine("Invalid input: Please enter 1 for CASH or 2 for CARD");
    Path1 = Console.ReadLine().ToLower();
}
if (Path1 == "1")
{
    payWithCard = false;
    Console.Clear();
}
else if(Path1 == "2")
{
    payWithCard = true;
    Console.Clear();
}

if (payWithCard == false)//if user does not enter card
{
    goto cash;//run code starting where goto identifier is 
}
else if (payWithCard)//if user enters card
{
    goto card;//run code starting where goto identifier is 
}


cash://goto idenifier for cash payments
{
    Console.WriteLine("Your total today is ${0}", totalDue);
    Console.WriteLine("\nIf you are paying with coins please enter those first, one at a time."); //prompt 

    while (totalDue > 0)//while total due is more than 0 - while loop runs to calculate total due - value of currency entered (moneyEntered) and adds that value to runnin gtotal of totalMoneyEntered
    {
        Console.WriteLine("What currency did you enter? (penny,nickel,dime,quarter,one,five,ten,twenty,fifty,hundred) : ");//prompt to user for input
        moneyEntered = Console.ReadLine().ToLower();//storing user data
        if (moneyEntered == "penny") //checking user input
        {
            totalDue = totalDue - pennies.value;
            totalMoneyEntered = totalMoneyEntered + pennies.value;
            pennies.count++;//increment penny.count in till
         
            if (totalDue <= 0)// if total due is less than or equal to 0 - break from while loop- no need for more payments
            {
                break;
            }

            Console.WriteLine("Remaining total {0}", totalDue.ToString("C"));//display remaining total due - formatting representaion of total due to currency
        }
        else if (moneyEntered == "nickel")
        {
            totalDue = totalDue - nickels.value;
            totalMoneyEntered = totalMoneyEntered + nickels.value;
            nickels.count++;
           
            if (totalDue <= 0)
            {
                break;
            }

            Console.WriteLine("Remaining total {0}", totalDue.ToString("C"));
        }
        else if (moneyEntered == "dime")
        {
            totalDue = totalDue - dimes.value;
            totalMoneyEntered = totalMoneyEntered + dimes.value;
            dimes.count++;
           
            if (totalDue <= 0)
            {
                break;
            }

            Console.WriteLine("Remaining total {0}", totalDue.ToString("C"));
        }
        else if (moneyEntered == "quarter")
        {
            totalDue = totalDue - quarters.value;
            totalMoneyEntered = totalMoneyEntered + quarters.value;
            quarters.count++;
           
            if (totalDue <= 0)
            {
                break;
            }

            Console.WriteLine("Remaining total {0}", totalDue.ToString("C"));
        }
        else if (moneyEntered == "one")
        {
            totalDue = totalDue - ones.value;
            totalMoneyEntered = totalMoneyEntered + ones.value;
            ones.count++;
          
            if (totalDue <= 0)
            {
                break;
            }

            Console.WriteLine("Remaining total {0}", totalDue.ToString("C"));
        }
        else if (moneyEntered == "five")
        {
            totalDue = totalDue - fives.value;
            totalMoneyEntered = totalMoneyEntered + fives.value;
            fives.count++;
          
            if (totalDue <= 0)
            {
                break;
            }

            Console.WriteLine("Remaining total {0}", totalDue.ToString("C"));
        }
        else if (moneyEntered == "ten")
        {
            totalDue = totalDue - tens.value;
            totalMoneyEntered = totalMoneyEntered + tens.value;
            tens.count++;
            
            if (totalDue <= 0)
            {
                break;
            }

            Console.WriteLine("Remaining total {0}", totalDue.ToString("C"));
        }
        else if (moneyEntered == "twenty")
        {
            totalDue = totalDue - twenties.value;
            totalMoneyEntered = totalMoneyEntered + twenties.value;
            twenties.count++;
           
            if (totalDue <= 0)
            {
                break;
            }

            Console.WriteLine("Remaining total {0}", totalDue.ToString("C"));
        }
        else if (moneyEntered == "fifty")
        {
            totalDue = totalDue - fifties.value;
            totalMoneyEntered = totalMoneyEntered + fifties.value;
            fifties.count++;
           
            if (totalDue <= 0)
            {
                break;
            }

            Console.WriteLine("Remaining total {0}", totalDue.ToString("C"));
        }
        else if (moneyEntered == "hundred")
        {
            totalDue = totalDue - hundreds.value;
            totalMoneyEntered = totalMoneyEntered + hundreds.value;
            hundreds.count++;
           
            if (totalDue <= 0)
            {
                break;
            }

            Console.WriteLine("Remaining total {0}", totalDue.ToString("C"));
        }
        else//input validation
        {
            Console.WriteLine("ERROR: MUST ENTER ONE OF THE FOLLOWING : (penny,nickel,dime,quarter,one,five,ten,twenty,fifty,hundred )");
            totalDue = totalDue;
        }

    }
   
    
    Console.WriteLine("Your total today was {0}", itemTotal.ToString("C"));
    Console.WriteLine("You paid {0}", totalMoneyEntered.ToString("C"));
    paymentCashAmount = totalMoneyEntered.ToString("C");


    if (totalDue < 0) //if the total due is less than 0 - customer gave too much money and needs change 
    {
        change = totalMoneyEntered - itemTotal;//calculating due by subtracting the itemtotal from total money enetered
        MakeChange(change, 0, currency);//calling makechange(greedy algorythm to determine best way to give change) sending change, 0, and currency array as arguments
                                        //checking to see if there is enough currency in the till to make change using values assigned to currency in MakeChange and values assigned to count in struct till
        if (currency[0] > pennies.count)
        {
            Console.WriteLine("TRANSACTION CANCELLED - CANNOT GIVE CHANGE");//output
            Console.WriteLine("Would you like to pay with CARD? (y/n)");//prompt for input
            Path1 = Console.ReadLine().ToString().ToLower();//storing user input

            while (Path1 != "y" && Path1 != "n")//input validation 
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to pay with card or 'N' to exit the console");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y") 
            {
                payWithCard = true; //will run card section of code 
            }
            else if (Path1 == "n")//will cancel transaction 
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");
                goto cancelled;
            }
        }
        else if (currency[1] > nickels.count)
        {
            Console.WriteLine("TRANSACTION CANCELLED - CANNOT GIVE CHANGE");
            Console.WriteLine("Would you like to pay with CARD? (y/n)");
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to pay with card or 'N' to exit the console");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");
                goto cancelled;
            }

        }
        else if (currency[2] > dimes.count)
        {
            Console.WriteLine("TRANSACTION CANCELLED - CANNOT GIVE CHANGE");
            Console.WriteLine("Would you like to pay with CARD? (y/n)");
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to pay with card or 'N' to exit the console");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");
                goto cancelled;
            }

        }
        else if (currency[3] > quarters.count)
        {
            Console.WriteLine("TRANSACTION CANCELLED - CANNOT GIVE CHANGE");
            Console.WriteLine("Would you like to pay with CARD? (y/n)");
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to pay with card or 'N' to exit the console");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");
                goto cancelled;
            }

        }
        else if (currency[4] > ones.count)
        {
            Console.WriteLine("TRANSACTION CANCELLED - CANNOT GIVE CHANGE");
            Console.WriteLine("Would you like to pay with CARD? (y/n)");
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to pay with card or 'N' to exit the console");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");
                goto cancelled;
            }
        }
        else if (currency[5] > fives.count)
        {
            Console.WriteLine("TRANSACTION CANCELLED - CANNOT GIVE CHANGE");
            Console.WriteLine("Would you like to pay with CARD? (y/n)");
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to pay with card or 'N' to exit the console");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");
                goto cancelled;
            }

        }
        else if (currency[6] > tens.count)
        {
            Console.WriteLine("TRANSACTION CANCELLED - CANNOT GIVE CHANGE");
            Console.WriteLine("Would you like to pay with CARD? (y/n)");
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to pay with card or 'N' to exit the console");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");
                goto cancelled;
            }

        }
        else if (currency[7] > twenties.count)
        {
            Console.WriteLine("TRANSACTION CANCELLED - CANNOT GIVE CHANGE");
            Console.WriteLine("Would you like to pay with CARD? (y/n)");
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to pay with card or 'N' to exit the console");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");
                goto cancelled;
            }

        }
        else if (currency[8] > fifties.count)
        {
            Console.WriteLine("TRANSACTION CANCELLED - CANNOT GIVE CHANGE");
            Console.WriteLine("Would you like to pay with CARD? (y/n)");
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to pay with card or 'N' to exit the console");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");
                goto cancelled;
            }
        }
        else if (currency[9] > hundreds.count)
        {
            Console.WriteLine("TRANSACTION CANCELLED - CANNOT GIVE CHANGE");
            Console.WriteLine("Would you like to pay with CARD? (y/n)");
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to pay with card or 'N' to exit the console");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");
                goto cancelled;
            }
        }
        else//if there is enough currency in till to give change
        {
            Console.WriteLine("Your change is : " + Math.Round(change, 2).ToString("C"));
            Console.WriteLine("Giving change back in : ");
            ShowChange(currency);
            goto cancelled;
        }
    }
}



card://goto identifier --- code for card payments
{
    if (payWithCard)
    {

        Console.WriteLine("Would you like cash back? (y/n)");//propt to user for input
        Path1 = Console.ReadLine().ToString().ToLower();

        while (Path1 != "y" && Path1 != "n")
        {
            Console.WriteLine("Invalid input: Please enter 'Y' for cash back or 'N' for no cash back");
            Path1 = Console.ReadLine().ToString().ToLower();
        }
        if (Path1 == "y")
        {
            cashBack = true;
            Console.Clear();
        }
        else if (Path1 == "n")
        {
            cashBack = false;
            Console.Clear();
        }

        if (cashBack)//while cashback is true ruun the following
        {
        cashBack:
            Console.WriteLine("How much would you like? $5, $10, $20, $50, $100");//prompt to user
            cashBackAmount = Console.ReadLine();//storing user data
           
            if (cashBackAmount == "$5" || cashBackAmount == "5")//verifying user input
            {
                currency[5] += 1;//adds 1 to value at currency element  - to be used to see if till can give cash back
                change = 5;//set change to equal cash back requested - this will be used to calculate how to give user cash back
            }
            else if (cashBackAmount == "$10" || cashBackAmount == "10")
            {
                currency[6] += 1;
                change = 10;
            }
            else if (cashBackAmount == "$20" || cashBackAmount == "20")
            {
                currency[7] += 1;
                change = 20;
            }
            else if (cashBackAmount == "$50" || cashBackAmount == "50")
            {
                currency[8] += 1;
                change = 50;
            }
            else if (cashBackAmount == "$100" || cashBackAmount == "100")
            {
                currency[9] += 1;
                change = 100;
            }
            else
            {
                Console.WriteLine("ERROR : INVALID INPUT - PLEASE ENTER $5, $10, $20, $50, OR $100");//output
                goto cashBack;
            }
        }
        if (currency[5] > fives.count)
        {
            Console.WriteLine("ERROR : CANNOT GIVE CASH BACK - WOULD YOU LIKE TO PROCEED WITHOUT? (y/n)?");//propt to user
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to continue or 'N' to cancel the transaction");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
                change = 0;//sets change to 0 since no cashback is rquested
                Console.Clear();
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");//output
                goto cancelled;//run code at cancelled goto identifier
            }
         
        }
        else if (currency[6] > tens.count)
        {
            Console.WriteLine("ERROR : CANNOT GIVE CASH BACK - WOULD YOU LIKE TO PROCEED (y/n)?");
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to continue or 'N' to cancel the transaction");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
                change = 0;//sets change to 0 since no cashback is rquested
                Console.Clear();
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");//output
                goto cancelled;//run code at cancelled goto identifier
            }

        }
        else if (currency[7] > twenties.count)
        {
            Console.WriteLine("ERROR : CANNOT GIVE CASH BACK - WOULD YOU LIKE TO PROCEED (y/n)?");
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to continue or 'N' to cancel the transaction");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
                change = 0;//sets change to 0 since no cashback is rquested
                Console.Clear();
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");//output
                goto cancelled;//run code at cancelled goto identifier
            }

        }
        else if (currency[8] > fifties.count)
        {
            Console.WriteLine("ERROR : CANNOT GIVE CASH BACK - WOULD YOU LIKE TO PROCEED (y/n)?");
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to continue or 'N' to cancel the transaction");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
                change = 0;//sets change to 0 since no cashback is rquested
                Console.Clear();
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");//output
                goto cancelled;//run code at cancelled goto identifier
            }

        }
        else if (currency[9] > hundreds.count)
        {
            Console.WriteLine("ERROR : CANNOT GIVE CASH BACK - WOULD YOU LIKE TO PROCEED (y/n)?");
            Path1 = Console.ReadLine().ToString().ToLower();

            while (Path1 != "y" && Path1 != "n")
            {
                Console.WriteLine("Invalid input: Please enter 'Y' to continue or 'N' to cancel the transaction");
                Path1 = Console.ReadLine().ToString().ToLower();
            }
            if (Path1 == "y")
            {
                payWithCard = true;
                change = 0;//sets change to 0 since no cashback is rquested
                Console.Clear();
            }
            else if (Path1 == "n")
            {
                payWithCard = false;
                Console.WriteLine("TRANSACTION CANCELLED");//output
                goto cancelled;//run code at cancelled goto identifier
            }

        }


    entercard:
        Console.WriteLine("PLEASE NOTE - WE ONLY ACCEPT AMERICAN EXPRESS, MASTERCARD, VISA, AND DISCOVER");
        Console.WriteLine("Please enter your card number (no spaces or dashes) :");//prompt to user for input
        cardNum = Console.ReadLine();//stores user data
        Mod10Check(cardNum);//verifies user card #

        while (Mod10Check(cardNum) == false || cardNum.Length < 12)//if card # is invalid - (not divisible by 10 or has less than 12 characters)
        {
            Console.WriteLine("ERROR : INVALID CARD NUMBER");//output
            Console.WriteLine("Please enter your card number:");//prompt to user for input
            cardNum = Console.ReadLine();//storing user data
            Mod10Check(cardNum);//verifies user card#
        }
        
        if (Mod10Check(cardNum) == true && cardNum.Length >= 12 && cardNum.Length <= 16)//if the card is valid
        {
            char[] numArray = new char[cardNum.Length];//declaring a character array and giving it the size of the length of the user card #
            cardNum.CopyTo(0, numArray, 0, cardNum.Length);//copies user card number to the array
            accountNum = cardNum.Remove(0, 6);//removes the first 6 characters from card number and assigns that value to account number
            accountNum = accountNum.Remove(accountNum.Length - 1);//removes the last digit in account number - this leaves us with the account number for the card holder

            if (numArray[0] == '3')//checks the first element in the array holding card number to see which major card company the card belongs to
            {
                Console.WriteLine("American Express card # {0}", cardNum);//outputs card mvendor and card number
                MoneyRequest(accountNum, (totalDue + change));//calls MoneyRequest function to see if the user has enough funds in their account to pay the balance - account number and total due + any cash back they requested are sent as arguments
                cardVendor = "American Express";
            }
            else if (numArray[0] == '4')
            {
                Console.WriteLine("Visa card # {0}", cardNum);
                MoneyRequest(accountNum, (totalDue + change));
                cardVendor = "Visa";
            }
            else if (numArray[0] == '5')
            {
                Console.WriteLine("Mastercard card # {0}", cardNum);
                MoneyRequest(accountNum, (totalDue + change));
                cardVendor = "Mastercard";
            }
            else if (numArray[0] == '6')
            {
                Console.WriteLine("Discover card # {0}", cardNum);
                MoneyRequest(accountNum, (totalDue + change));
                cardVendor = "Discover";
            }
            else if (numArray[0] != '3' && numArray[0] != '4' && numArray[0] != '5' && numArray[0] != '6') //merchant ID doesnt match vendors accepted
            {
                Console.WriteLine("ERROR : WE ONLY ACCEPT AMERICAN EXPRESS, MASTERCARD, VISA, OR DISCOVER");//output
                Console.WriteLine("Would you like to pay with another card? ('Y' for yes or 'N' for no)");//asking for input
                
                Path1 = Console.ReadLine().ToString().ToLower();//storing user input

                while (Path1 != "y" && Path1 != "n")//input validation
                {
                    Console.WriteLine("Invalid input; Enter 'y' for yes and 'n' for no");//ouput
                    Console.WriteLine("Would you like to pay with another card? ('Y' for yes or 'N' for no)");//prompt for input
                    Path1 = Console.ReadLine().ToString().ToLower();
                }

                if (Path1 == "y")//if they choose yes
                {
                    payWithCard = true;
                    goto entercard;
                }
                else if (Path1 == "n") //if no
                {
                    payWithCard = false;
                    Console.WriteLine("TRANSACTION CANCELLED");
                    goto cancelled;
                }
           
            }


            Path1 = MoneyRequest(accountNum, (totalDue + change))[1];


            if (Path1 == "declined" && cashBack == false)//if the card is declined and the user did not request cash back
            {
                Console.WriteLine("CARD DECLINED");//output
                Console.WriteLine("Remaining balance: {0}", totalDue.ToString("C"));//output

        declined1://goto identifier 

                Console.WriteLine("Would you like to pay with CASH or CARD or would you like to CANCEL the transaction?");
                Console.WriteLine("Please enter '1' for Cash, '2' for CARD, or '3' to CANCEL");//prompt to user for input
                cashOrCard = Console.ReadLine().ToLower();//declaring and initialzing string variable to hold user input
              
                if (cashOrCard == "1")//if user enters cash
                {
                    goto cash;//runs cash payment code
                }
                else if (cashOrCard == "2")//if user enters card
                {
                    goto card;//runs card payment code 
                }
                else if (cashOrCard == "3")//if user enteres cancel
                {
                    Console.WriteLine("TRANSACTION CANCELLED");//output
                    cardAmount = "NULL";//setting cardamount to "null" because transaction was cancelled
                    cardVendor = "NULL"; ;//setting card vendor to "null" because transaction was cancelled
                }
                else if (cashOrCard != "1" && cashOrCard != "2" && cashOrCard != "3")//input validation
                {
                    Console.WriteLine("ERROR: INVALID INPUT\n Please enter '1' , '2', or '3'");//output
                    goto declined1;//runs code at cancelled identidier
                }

            }

            if (Path1 == "declined" && cashBack == true)//if the card is declined and the user did not request cash back
            {
                Console.WriteLine("CARD DECLINED");//output
                Console.WriteLine("Remaining balance: {0}", totalDue.ToString("C"));//output

          declined2://goto identifier 

                Console.WriteLine("Would you like to pay with a new CARD or would you like to CANCEL the transaction?");
                Console.WriteLine("Please enter '1' for new CARD or '2' to CANCEL:");//prompt to user for input
                cashOrCard = Console.ReadLine().ToLower();//declaring and initialzing string variable to hold user input
                
                if (cashOrCard == "1")//if user enters card
                {
                    goto card;//runs card payment code 
                }
                else if (cashOrCard == "2")//if user enteres cancel
                {
                    Console.WriteLine("TRANSACTION CANCELLED");//output
                    cardAmount = "NULL";//setting cardamount to "null" because transaction was cancelled
                    cardVendor = "NULL"; ;//setting card vendor to "null" because transaction was cancelled
                }
                else if (cashOrCard != "1" && cashOrCard != "2")//input validation
                {
                    Console.WriteLine("ERROR: INVALID INPUT\n Please enter '1' or '2'");//output
                    goto declined2;//runs code at cancelled identidier
                }

            }


            else if(Path1 != (totalDue + change).ToString() && Path1 != "declined" && cashBack == true)//if card declines but user has asked for cash back
            {
                totalDue = totalDue - decimal.Parse(Path1);
                Console.WriteLine("INSUFFICIENT FUNDS");//output
                Console.WriteLine("Remaining balance: {0}", (totalDue.ToString("C")));//output 
            declined3:
                Console.WriteLine("Would you like to pay with a new CARD or CANCEL the transaction?");
                Console.WriteLine("Please enter '1' for new CARD or '2' to CANCEL");//prompt for user input
                cashOrCard = Console.ReadLine().ToLower();

                if (cashOrCard == "1")//if user enters card
                {
                    goto card;//runs card payment code 
                }
                else if (cashOrCard == "2")//if user enteres cancel
                {
                    Console.WriteLine("TRANSACTION CANCELLED");//output
                    cardAmount = "NULL";//setting cardamount to "null" because transaction was cancelled
                    cardVendor = "NULL"; ;//setting card vendor to "null" because transaction was cancelled
                }
                else if (cashOrCard != "1" && cashOrCard != "2")//input validation
                {
                    Console.WriteLine("ERROR: INVALID INPUT\n Please enter '1' or '2'");//output
                    goto declined3;//runs code at cancelled identidier
                }

            }

            else if (Path1 != (totalDue + change).ToString() && Path1 != "declined" && cashBack == false)//if card declines but user has asked for cash back
            {
                totalDue = totalDue - decimal.Parse(Path1);
                Console.WriteLine("INSUFFICIENT FUNDS");//output
                Console.WriteLine("Remaining balance: {0}", totalDue.ToString("C"));//output 
        declined4:       
                Console.WriteLine("Would you like to pay with CASH, a new CARD, or CANCEL the transaction?");//prompt for user input
                Console.WriteLine("Please enter '1' for CASH, '2' new CARD or '3' to CANCEL");//prompt for user input
                cashOrCard = Console.ReadLine().ToLower();

                if(cashOrCard == "1")
                {
                    goto cash;
                }
               else if (cashOrCard == "2")//if user chooses card
                {
                    goto card;//runs card payment code 
                }
                else if (cashOrCard == "3")//if user chooses cancel
                {
                    Console.WriteLine("TRANSACTION CANCELLED");//output
                    cardAmount = "NULL";//setting cardamount to "null" because transaction was cancelled
                    cardVendor = "NULL"; ;//setting card vendor to "null" because transaction was cancelled
                }
                else if (cashOrCard != "1" && cashOrCard != "2")//input validation
                {
                    Console.WriteLine("ERROR: INVALID INPUT\n Please enter '1' or '2'");//output
                    goto declined4;//runs code at cancelled identidier
                }

            }

            if (Path1 == (totalDue + change).ToString() && cashBack == true)//if card does not decline
            {
                cardAmount = totalDue.ToString("C");
              
                Console.WriteLine("{0} paid. Remaining balance $0", totalDue.ToString("C"));//output
                Console.WriteLine("Please take cash requested.");//output
              
                MakeChange(change, 0, currency);//calls makechance function to determine bestway to give cash back
                ShowChange(currency);//output to let user know how they received cashback
            }
            else if (Path1 == (totalDue + change).ToString() && cashBack == false)//if card does not decline
            {
                Console.WriteLine("{0} paid. Remaining balance $0", totalDue.ToString("C"));//output
            }
        }
    }
}


if (payWithCard == true)//if cuustomer paid with a card
{
    cardAmount = totalDue.ToString("C");//setting card amount to string representation of totaldue 
}


cancelled://goto identifier for cacnelled transactions
Console.WriteLine("Thank you and please come again!");//output

paymentCardVendorAmount = cardVendor + "," + cardAmount; //setting string variable to equal values of cardvendor and cardamount to be used as argument
changeGiven = change.ToString("C");//converting change to string and assignin that value to changegiven to be used as an argument
string arguments = transactionNum + " " + transactionDate + " " + transactionTime.Replace(' ', '-') + " " + paymentCashAmount + " " + paymentCardVendorAmount + " " + changeGiven;/*string of vars
                                                                                                                                                                                   * separated by space
                                                                                                                                                                                   * to be sent to transaction_logging*/

//GREEDY ALGORHYTHM

static void MakeChange(decimal origAmount, decimal remainAmount, int[] currency)
{
    if ((origAmount % 100m) < origAmount)//currency array element is set to origAmount(change) divided by 100
    {
        currency[9] = (int)(origAmount / 100);//if origAmount is divisible by 100 - currency[9] is set to the quotient
        remainAmount = origAmount % 100m;//remainamount is remainder or origAmount divided by 100
        origAmount = remainAmount;//origamount is set to remainAmounts value 
    }
    if ((origAmount % 50m) < origAmount)
    {
        currency[8] = (int)(origAmount / 50);
        remainAmount = origAmount % 50;
        origAmount = remainAmount;
    }
    if ((origAmount % 20m) < origAmount)
    {
        currency[7] = (int)(origAmount / 20);
        remainAmount = origAmount % 20;
        origAmount = remainAmount;
    }
    if ((origAmount % 10m) < origAmount)
    {
        currency[6] = (int)(origAmount / 10);
        remainAmount = origAmount % 10;
        origAmount = remainAmount;
    }
    if ((origAmount % 5m) < origAmount)
    {
        currency[5] = (int)(origAmount / 5);
        remainAmount = origAmount % 5;
        origAmount = remainAmount;
    }
    if ((origAmount % 1m) < origAmount)
    {
        currency[4] = (int)(origAmount / 1);
        remainAmount = origAmount % 1;
        origAmount = remainAmount;
    }
    if ((origAmount % 0.25m) < origAmount)
    {
        currency[3] = (int)(origAmount / 0.25m);
        remainAmount = origAmount % 0.25m;
        origAmount = remainAmount;
    }
    if ((origAmount % 0.1m) < origAmount)
    {
        currency[2] = (int)(origAmount / 0.1m);
        remainAmount = origAmount % 0.1m;
        origAmount = remainAmount;
    }
    if ((origAmount % 0.05m) < origAmount)
    {
        currency[1] = (int)(origAmount / 0.05m);
        remainAmount = origAmount % 0.05m;
        origAmount = remainAmount;
    }
    if ((origAmount % 0.01m) < origAmount)
    {
        currency[0] = (int)(origAmount / 0.01m);
        remainAmount = origAmount % 0.01m;
        origAmount = remainAmount;
    }
}



static void ShowChange(int[] arr)//showchange function accepts int array (currency) as argument and uses the array for output
{
    //if the array element does not equal 0 - output the value + string literal using chart below
    if (arr[9] > 0) Console.WriteLine(arr[9] + " Hundreds");
    if (arr[8] > 0) Console.WriteLine(arr[8] + " Fifties");
    if (arr[7] > 0) Console.WriteLine(arr[7] + " Twenties");
    if (arr[6] > 0) Console.WriteLine(arr[6] + " Tens");
    if (arr[5] > 0) Console.WriteLine(arr[5] + " Fives");
    if (arr[4] > 0) Console.WriteLine(arr[4] + " Ones");
    if (arr[3] > 0) Console.WriteLine(arr[3] + " Quarters");
    if (arr[2] > 0) Console.WriteLine(arr[2] + " Dimes");
    if (arr[1] > 0) Console.WriteLine(arr[1] + " Nickels");
    if (arr[0] > 0) Console.WriteLine(arr[0] + " Pennies");
}



static bool Mod10Check(string creditCardNumber)

{
    //// check whether input string is null or empty
    if (string.IsNullOrEmpty(creditCardNumber))
    {
        return false;
    }

    //// 1.	Starting with the check digit double the value of every other digit 
    //// 2.	If doubling of a number results in a two digits number, add up
    ///   the digits to get a single digit number. This will results in eight single digit numbers                    
    //// 3. Get the sum of the digits
    int sumOfDigits = creditCardNumber.Where((e) => e >= '0' && e <= '9')
                    .Reverse()
                    .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                    .Sum((e) => e / 10 + e % 10);


    //// If the final sum is divisible by 10, then the credit card number
    //   is valid. If it is not divisible by 10, the number is invalid.            
    return sumOfDigits % 10 == 0;//boolean 
}




static string[] MoneyRequest(string account_number, decimal amount)
{
    Random rnd = new Random();
    //50% CHANCE TRANSACTION PASSES OR FAILS
    bool pass = rnd.Next(100) < 50;
    //50% CHANCE THAT A FAILED TRANSACTION IS DECLINED
    bool declined = rnd.Next(100) < 50;
    if (pass)
    {
        return new string[] { account_number, amount.ToString() };
    }
    else
    {
        if (!declined)
        {
            return new string[] { account_number, (amount / rnd.Next(2, 6)).ToString() };
        }
        else
        {
            return new string[] { account_number, "declined" };
        }//end if
    }//end if
}//end if




//CALLING TRANSACTION LOG PROGRAM TO RUN AND PASSING ARGUMENTS IN "ARGUMENTS" VARIABLE
ProcessStartInfo startInfo = new ProcessStartInfo();
startInfo.FileName = "C:\\Users\\wiggi\\source\\repos\\Transaction_Logging\\Transaction_Logging\\bin\\Debug\\net6.0\\Transaction_Logging.exe";
startInfo.Arguments = arguments;
Process.Start(startInfo);




/*user defined data type - structure - holds values for denominations or currency, what the value of the currency is, 
 * and how many of the currency is in the till*/
struct till
{
    public string denomination;
    public decimal value;
    public int count;
}
