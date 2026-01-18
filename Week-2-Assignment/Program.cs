using System; // Allows us to use Console and basic system functions

class SimpleBankSystem
{
    // Stores the user's bank balance
    static double balance = 1000.0;

    // Stores the correct PIN for login
    static int correctPin = 1234;

    static void Main(string[] args)
    {
        int attempts = 0;           // Counts how many PIN attempts are used
        bool accessGranted = false; // Checks if login is successful

        // ---------- LOGIN SYSTEM ----------
        while (attempts < 3) // User gets only 3 attempts
        {
            try
            {
                Console.Write("Enter your PIN: ");
                int enteredPin = int.Parse(Console.ReadLine()); // Reads PIN input

                if (enteredPin == correctPin) // Checks if PIN is correct
                {
                    accessGranted = true; // Login successful
                    break;                // Exit the login loop
                }
                else
                {
                    attempts++; // Increase attempt count
                    Console.WriteLine("Incorrect PIN. Attempts left: " + (3 - attempts));
                }
            }
            catch
            {
                // Runs if user enters non-numeric input
                Console.WriteLine("Invalid input. Please enter numbers only.");
                attempts++;
            }
        }

        // If login fails after 3 attempts
        if (!accessGranted)
        {
            Console.WriteLine("Account locked due to too many incorrect attempts.");
            return; // Ends the program
        }

        int choice = 0; // Stores menu choice

        // ---------- BANKING MENU ----------
        do
        {
            Console.WriteLine("\n--- Simple Banking System ---");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            try
            {
                choice = int.Parse(Console.ReadLine()); // Reads user choice

                // Switch statement to select operation
                switch (choice)
                {
                    case 1:
                        Deposit(); // Calls deposit function
                        break;

                    case 2:
                        Withdraw(); // Calls withdraw function
                        break;

                    case 3:
                        CheckBalance(); // Calls balance check function
                        break;

                    case 4:
                        Console.WriteLine("Thank you for using the banking system.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select 1–4.");
                        break;
                }
            }
            catch
            {
                // Runs if user enters invalid menu input
                Console.WriteLine("Please enter a valid number.");
            }

        } while (choice != 4); // Loop runs until user chooses Exit
    }

    // ---------- DEPOSIT FUNCTION ----------
    static void Deposit()
    {
        try
        {
            Console.Write("Enter amount to deposit: ");
            double amount = double.Parse(Console.ReadLine()); // Reads deposit amount

            if (amount > 0) // Checks if amount is positive
            {
                balance += amount; // Adds amount to balance
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Amount must be greater than zero.");
            }
        }
        catch
        {
            // Runs if user enters invalid deposit input
            Console.WriteLine("Invalid input. Please enter a numeric value.");
        }
    }

    // ---------- WITHDRAW FUNCTION ----------
    static void Withdraw()
    {
        try
        {
            Console.Write("Enter amount to withdraw: ");
            double amount = double.Parse(Console.ReadLine()); // Reads withdrawal amount

            if (amount > 0) // Checks if amount is positive
            {
                if (amount <= balance) // Checks if balance is sufficient
                {
                    balance -= amount; // Deducts amount from balance
                    Console.WriteLine("Withdrawal successful.");
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }
            else
            {
                Console.WriteLine("Amount must be greater than zero.");
            }
        }
        catch
        {
            // Runs if user enters invalid withdrawal input
            Console.WriteLine("Invalid input. Please enter a numeric value.");
        }
    }

    // ---------- BALANCE CHECK FUNCTION ----------
    static void CheckBalance()
    {
        Console.WriteLine("Your current balance is: " + balance);
    }
}


