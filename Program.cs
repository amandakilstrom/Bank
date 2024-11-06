namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] bankAccount = {
                "account1",
                "account2",
                "account3",
                "account4",
                "account5",
                "account6",
                "account7",
                "account8",
                "account9",
                "account10" };

            Double[] accountBalance = new Double[10];

            bool menuSelection = true;

            // Varibels used in the diffrent cases in the menu
            String account = " ";
            Double deposit;
            Double withdraw;
            int accountNumber;

            while (menuSelection)
            {
                // Main menu
                Console.WriteLine("Welcome to the bank!\nMenu" +
                    "\n1 Make a deposit" +
                    "\n2 Make a withdraw" +
                    "\n3 Show balance on one account" +
                    "\n4 Print a list of all accounts and balances" +
                    "\n5 Exit");
                Console.Write("Choice: ");
                String menuChoice = Console.ReadLine();

                Console.Clear();

                // switch case with the different menu options
                switch (menuChoice)
                {
                    // Make a deposit
                    case "1":
                        Console.WriteLine("Which account would you like to make a deposit to?");
                        account = Console.ReadLine().ToLower();

                        accountNumber = Array.IndexOf(bankAccount, account);

                        if (accountNumber == -1)
                        {
                            Console.WriteLine("The account does not exist in the bank");
                            BackToMenu();
                            break;
                        }

                        Console.WriteLine("How much would you like to deposit?");
                        Double.TryParse(Console.ReadLine(), out deposit);

                        if (deposit < 0)
                        {
                            Console.WriteLine("You cannot deposit a negative amount");
                        }
                        else if (deposit > 0)
                        {
                            accountBalance[accountNumber] = accountBalance[accountNumber] + deposit;
                        }

                        BackToMenu();
                        break;
                    // Make a withdraw
                    case "2":
                        Console.WriteLine("Which account would you like to make a withdrawal from?");
                        account = Console.ReadLine().ToLower();

                        accountNumber = Array.IndexOf(bankAccount, account);

                        if (accountNumber == -1)
                        {
                            Console.WriteLine("The account does not exist in the bank");
                            BackToMenu();
                            break;
                        }

                        Console.WriteLine("How much would you like to withdraw?");
                        Double.TryParse(Console.ReadLine(), out withdraw);

                        if (withdraw < 0)
                        {
                            Console.WriteLine("You cannot withdraw a negative amount");
                        }
                        else if (accountBalance[accountNumber] - withdraw < 0)
                        {
                            Console.WriteLine("There is not enough money in the account");
                        }
                        else if (withdraw > 0)
                        {
                            accountBalance[accountNumber] = accountBalance[accountNumber] - withdraw;
                        }

                        BackToMenu();
                        break;
                    // Show balance on one account
                    case "3":
                        Console.WriteLine("Which account would you like to check the balance of?");
                        account = Console.ReadLine().ToLower();

                        accountNumber = Array.IndexOf(bankAccount, account);

                        if (accountNumber == -1)
                        {
                            Console.WriteLine("The account does not exist in the bank");
                            BackToMenu();
                            break;
                        }

                        Console.WriteLine($"The account {bankAccount[accountNumber]} has a balance of {accountBalance[accountNumber]} SEK");

                        BackToMenu();
                        break;
                    // Show all accounts balance
                    case "4":
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine($"The account {bankAccount[i]} has a balance of {accountBalance[i]} SEK");
                        }

                        BackToMenu();
                        break;
                    // Exit program
                    case "5":
                        menuSelection = false;
                        break;
                    default:
                        // Gives an error message if the user does not enter a number between 1 and 5
                        Console.WriteLine("Välj ett menyval mellan 1 - 5");

                        BackToMenu();
                        break;
                }
            }
        }

        // A method to return to the main menu
        static void BackToMenu()
        {
            Console.WriteLine("Tryck enter för att komma till huvudmeny");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
